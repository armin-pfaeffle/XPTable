using Microsoft.DotNet.DesignTools.Editors;
using System.ComponentModel;
using System.Diagnostics;
using XPTable.Models;

namespace XPTable.Designer.Server.ColumnCollectionEditor;

public partial class ColumnCollectionEditor : CollectionEditor
{
	private ColumnModel? _columnModel = null;

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
		// Note: Not needed ATM
		// _columnCollection = ( ColumnCollection ) value;

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

	// TODO: Remove due to no custom code?
	// protected override object SetItems( object editValue, object[ ] value )
	// {
	// 	Debug.WriteLine( "ColumnCollectionEditor.SetItems" );
	//
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
			typeof( GroupColumn )
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

		return column;
	}
}