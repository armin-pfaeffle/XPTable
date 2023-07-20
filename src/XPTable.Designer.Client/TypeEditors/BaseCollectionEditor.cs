using Microsoft.DotNet.DesignTools.Client.Proxies;
using XPTable.Designer.Client.Extensions;

namespace XPTable.Designer.Client.TypeEditors;

public abstract class BaseCollectionEditor : Microsoft.DotNet.DesignTools.Client.Editors.CollectionEditor
{
	private Form? _collectionForm;

	private string _helpTopic = string.Empty;

	protected BaseCollectionEditor( Type collectionType )
		: base( collectionType )
	{
	}

	/// <summary>
	/// Override the HelpTopic property to provide different topics,
	/// depending on selected property.
	/// </summary>
	protected override string? HelpTopic
		=> string.IsNullOrEmpty( _helpTopic ) ? base.HelpTopic : _helpTopic;

	/// <summary>
	/// Displaying help for the currently selected item in the property grid
	/// </summary>
	protected override void ShowHelp( )
	{
		ClearHelpTopic( );

		var propertyGrid = ( _collectionForm?.Controls ).GetPropertyGrid( );

		if ( propertyGrid is not null )
		{
			var gridItem = propertyGrid.SelectedGridItem;
			if ( gridItem?.GridItemType is GridItemType.Property or GridItemType.ArrayValue
				 && gridItem.PropertyDescriptor != null )
			{
				_helpTopic = $"{gridItem.PropertyDescriptor.ComponentType}.{gridItem.PropertyDescriptor!.Name}";
			}
		}

		base.ShowHelp( );

		ClearHelpTopic( );
	}

	/// <summary>
	/// If the property grid is available it's HelpVisible property is set to true, the help pane backcolor is changed and
	/// the CommandsVisibleIfAvailable property is set to true ((hot) commands are elsewhere known as designer verbs).
	/// </summary>
	/// <returns>The CollectionEditor.CollectionForm returned from base method</returns>
	protected override ICollectionForm CreateCollectionForm( ObjectProxy viewModel )
	{
		var collectionForm = base.CreateCollectionForm( viewModel );
		_collectionForm = collectionForm as Form;

		if ( _collectionForm is not null )
		{
			var propertyGrid = _collectionForm.Controls.GetPropertyGrid( );
			if ( propertyGrid is not null )
			{
				propertyGrid.HelpVisible = true;
				propertyGrid.HelpBackColor = SystemColors.InactiveCaption;
				propertyGrid.CommandsVisibleIfAvailable = true;

				// TODO: Do we really need it or can these hooks be removed?
				propertyGrid.PropertyValueChanged += OnPropertyChanged;
				propertyGrid.ControlAdded += OnControlAddedRemoved;
				propertyGrid.ControlRemoved += OnControlAddedRemoved;
			}

			var buttons = _collectionForm.Controls.GetButtons( );
			foreach ( var button in buttons )
			{
				if ( button.DialogResult is DialogResult.OK or DialogResult.Cancel )
				{
					button.Click += OnOkOrCancelClicked;
				}
			}
		}

		return collectionForm;
	}

	/// <summary>
	/// Update design-time HTML when OK button is clicked in the collection editor
	/// </summary>
	protected virtual void OnOkOrCancelClicked( object sender, EventArgs e )
	{
		ClearHelpTopic( );
	}

	/// <summary>
	/// Update design-time HTML when property is added or removed
	/// </summary>
	protected virtual void OnControlAddedRemoved( object sender, ControlEventArgs e )
	{
	}

	/// <summary>
	/// Update design-time HTML when property is changed
	/// </summary>
	protected virtual void OnPropertyChanged( object sender, PropertyValueChangedEventArgs e )
	{
	}

	protected virtual void ClearHelpTopic( )
	{
		_helpTopic = string.Empty;
	}
}