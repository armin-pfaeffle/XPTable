using Microsoft.DotNet.DesignTools.Editors;
using System.ComponentModel;
using Utilities;
using XPTable.Models;

namespace XPTable.Designer.Server.ColumnCollectionEditor;

public partial class ColumnCollectionEditor : CollectionEditor
{
	private ITypeDescriptorContext? _context;
	// private Chart? _chart;
	// private INameController? _nameController;
	private ColumnCollection columnCollection;


	public ColumnCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		: base( serviceProvider, collectionType )
	{
		Logger.Log( "ColumnCollectionEditor constructor" );
		
	}


	protected override CollectionEditorViewModel BeginEditValue( ITypeDescriptorContext context, object value )
	{
		Logger.Log( "ColumnCollectionEditor.BeginEditValue" );
		
		this.columnCollection = ( ColumnCollection ) value;

		// foreach (Column column in this.columnCollection)
		// {
		// 	column.PropertyChanged += new ColumnEventHandler(this.column_PropertyChanged);
		// }
		//
		// object newCollection = base.EditValue(context, isp, value);
		//
		// ColumnModel columns = (ColumnModel)context.Instance;
		//
		// if (columns.Table != null)
		// {
		// 	columns.Table.PerformLayout();
		// 	columns.Table.Refresh();
		// }

		return base.BeginEditValue( context, value );
		
		_context = context;
		// if ( context?.Instance is Chart chart )
		// 	// Save current control type descriptor context
		// 	_chart = chart;
		//
		// if ( ( value is ChartAreaCollection || value is LegendCollection ) && value is INameController controller )
		// {
		// 	_nameController = controller;
		// 	controller.DoSnapshot( true,
		// 		new EventHandler<NameReferenceChangedEventArgs>( OnNameReferenceChanging ),
		// 		new EventHandler<NameReferenceChangedEventArgs>( OnNameReferenceChanged ) );
		//
		// 	controller.IsColectionEditing = true;
		// }
		// else
		// {
		// 	_nameController = null;
		// }

		return base.BeginEditValue( context!, value );
	}

	protected override object EndEditValue( bool commitChange )
	{
		Logger.Log( "ColumnCollectionEditor.EndEditValue" );
		// if ( _nameController is not null )
		// {
		// 	_nameController.IsColectionEditing = false;
		// 	_nameController.DoSnapshot( false,
		// 		new EventHandler<NameReferenceChangedEventArgs>( OnNameReferenceChanging ),
		// 		new EventHandler<NameReferenceChangedEventArgs>( OnNameReferenceChanged ) );
		//
		// 	_nameController = null;
		// }

		return base.EndEditValue( commitChange );
	}

	protected override object SetItems( object editValue, object[ ] value )
	{
		Logger.Log( "ColumnCollectionEditor.SetItems" );
		
		var result = base.SetItems( editValue, value );

		// if ( _chart is null
		// 	 || _nameController is null
		// 	 || _context?.GetService( typeof( IComponentChangeService ) ) is not IComponentChangeService svc )
		// 	return result;
		//
		// if ( result is not IList newList )
		// 	return result;
		//
		// bool elementsRemoved = false;
		// foreach ( ChartNamedElement element in _nameController.Snapshot )
		// {
		// 	if ( newList.IndexOf( element ) < 0 )
		// 	{
		// 		elementsRemoved = true;
		// 		break;
		// 	}
		// }
		//
		// if ( elementsRemoved )
		// {
		// 	svc.OnComponentChanging( this._chart, null );
		// 	ChartNamedElement? defaultElement = ( ChartNamedElement? ) ( newList.Count > 0 ? newList[0] : null );
		// 	foreach ( ChartNamedElement element in _nameController.Snapshot )
		// 	{
		// 		if ( newList.IndexOf( element ) < 0 )
		// 			_nameController.OnNameReferenceChanged( new NameReferenceChangedEventArgs( element, defaultElement ) );
		// 	}
		//
		// 	svc.OnComponentChanged( this._chart, null, null, null );
		// }

		return result;
	}


	/*
	/// <summary>
	/// Called when [name reference changing].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="NameReferenceChangedEventArgs"/> instance containing the event data.</param>
	private void OnNameReferenceChanging( object? sender, NameReferenceChangedEventArgs e )
	{
		if ( _chart is not null && _context?.GetService( typeof( IComponentChangeService ) ) is IComponentChangeService svc )
			svc.OnComponentChanging( _chart, null );
	}

	/// <summary>
	/// Called when [name reference changed].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="NameReferenceChangedEventArgs"/> instance containing the event data.</param>
	private void OnNameReferenceChanged( object? sender, NameReferenceChangedEventArgs e )
	{
		if ( _chart is not null && _context?.GetService( typeof( IComponentChangeService ) ) is IComponentChangeService svc )
			svc.OnComponentChanged( _chart, null, null, null );
	}
	 */


	/// <summary>
	/// Gets the data types that this collection editor can contain.
	/// </summary>
	/// <returns>An array of data types that this collection can contain.</returns>
	protected override Type[ ] CreateNewItemTypes( )
	{
		Logger.Log( "ColumnCollectionEditor.CreateNewItemTypes" );
		
		return new Type[ ]
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
			typeof( GroupColumn )
		};
	}

	/// <summary>
	/// Create annotation instance in the editor 
	/// </summary>
	/// <param name="itemType">Item type.</param>
	/// <returns>Newly created item.</returns>
	protected override object CreateInstance( Type itemType )
	{
		Logger.Log( "ColumnCollectionEditor.CreateInstance" );
		
		Column column = (Column) base.CreateInstance(itemType);

		this.columnCollection.Add(column);

		// column.PropertyChanged += new ColumnEventHandler(this.column_PropertyChanged);

		return column;

		// // Generate unique name 
		// if ( Helpers.GetChartReference( Context.Instance ) is Chart chart )
		// 	annotation.Name = NextUniqueName( chart, itemType );
	}

	// /// <summary>
	// /// Finds the unique name for a new annotation being added to the collection
	// /// </summary>
	// /// <param name="control">Chart control reference.</param>
	// /// <param name="type">Type of the annotation added.</param>
	// /// <returns>Next unique chart annotation name</returns>
	// private static string NextUniqueName( Chart control, Type type )
	// {
	// 	// Find unique name
	// 	string result = string.Empty;
	// 	string prefix = type.Name;
	// 	for ( int i = 1; i < int.MaxValue; i++ )
	// 	{
	// 		result = prefix + i.ToString( CultureInfo.InvariantCulture );
	//
	// 		// Check whether the name is unique
	// 		if ( control.Annotations.IsUniqueName( result ) )
	// 		{
	// 			break;
	// 		}
	// 	}
	//
	// 	return result;
	// }
}
