using Microsoft.DotNet.DesignTools.Editors;
using System.ComponentModel;
using System.Diagnostics;
using XPTable.Events;
using XPTable.Models;

namespace XPTable.Designer.Server.ColumnCollectionEditor;

public partial class ColumnCollectionEditor : CollectionEditor
{
	private ColumnModel? _columnModel = null;

	private ColumnCollection? _columnCollection = null;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="serviceProvider"></param>
	/// <param name="collectionType">The type of the collection to be edited</param>
	public ColumnCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		: base( serviceProvider, collectionType )
	{
		Debug.WriteLine( "ColumnCollectionEditor constructor" );
	}


	protected override CollectionEditorViewModel BeginEditValue( ITypeDescriptorContext context, object value )
	{
		Debug.WriteLine( $"ColumnCollectionEditor.BeginEditValue (value: {value.GetType( )}, context.Instance: {context.Instance.GetType( )})" );

		if ( context.Instance is ColumnModel columnModel )
		{
			_columnModel = columnModel;
		}

		// Store access to ColumnCollection
		if ( value is ColumnCollection columnCollection )
		{
			_columnCollection = columnCollection;
		}

		return base.BeginEditValue( context, value );
	}

	protected override object EndEditValue( bool commitChange )
	{
		Debug.WriteLine( "ColumnCollectionEditor.EndEditValue" );

		if ( _columnModel?.Table != null )
		{
			Debug.WriteLine( "ColumnCollectionEditor.EndEditValue > Update Table" );

			_columnModel.Table.PerformLayout( );
			_columnModel.Table.Refresh( );
		}

		return base.EndEditValue( commitChange );
	}

	// Not used due to no custom code
	// protected override object SetItems( object editValue, object[ ] value )
	// {
	// 	var newCollection = base.SetItems( editValue, value );
	//
	// 	return newCollection;
	// }

	/// <summary>
	/// Gets the data types that this collection editor can contain.
	/// </summary>
	/// <returns>An array of data types that this collection can contain.</returns>
	protected override Type[ ] CreateNewItemTypes( )
	{
		Debug.WriteLine( "ColumnCollectionEditor.CreateNewItemTypes" );

		return new[ ]
		{
			typeof( TextColumn ),
			typeof( ButtonColumn ),
			typeof( CheckBoxColumn ),
			typeof( ColorColumn ),
			typeof( ComboBoxColumn ),
			typeof( DateTimeColumn ),
			typeof( ImageColumn ),
			typeof( NumberColumn ),
			typeof( DoubleColumn ),
			typeof( ProgressBarColumn ),
			typeof( GroupColumn ),
		};
	}

	/// <summary>
	/// Creates a new instance of the specified collection item type
	/// </summary>
	/// <param name="itemType">The type of item to create</param>
	/// <returns>A new instance of the specified object</returns>
	protected override object CreateInstance( Type itemType )
	{
		Debug.WriteLine( "ColumnCollectionEditor.CreateInstance" );

		var column = ( Column ) base.CreateInstance( itemType );

		_columnCollection?.Add( column );

		column.PropertyChanged += OnColumnPropertyChanged;

		return column;
	}

	/// <summary>
	/// Handler for a Column's PropertyChanged event
	/// </summary>
	/// <param name="sender">The object that raised the event</param>
	/// <param name="e">A ColumnEventArgs that contains the event data</param>
	private void OnColumnPropertyChanged( object sender, ColumnEventArgs e )
	{
		_columnCollection?.ColumnModel.OnColumnPropertyChanged( e );
	}
}