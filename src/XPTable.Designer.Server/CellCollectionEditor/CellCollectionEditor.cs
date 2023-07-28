using Microsoft.DotNet.DesignTools.Editors;
using System.ComponentModel;
using System.Diagnostics;
using XPTable.Models;

namespace XPTable.Designer.Server.CellCollectionEditor;

public partial class CellCollectionEditor : CollectionEditor
{
	private Row? _row = null;

	private CellCollection? _cellCollection = null;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="serviceProvider"></param>
	/// <param name="collectionType">The type of the collection to be edited</param>
	public CellCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		: base( serviceProvider, collectionType )
	{
		Debug.WriteLine( "CellCollectionEditor constructor" );
	}


	protected override CollectionEditorViewModel BeginEditValue( ITypeDescriptorContext context, object value )
	{
		Debug.WriteLine( $"CellCollectionEditor.BeginEditValue (value: {value.GetType( )}, context.Instance: {context.Instance.GetType( )})" );

		if ( context.Instance is Row row )
		{
			_row = row;
		}

		// Store access to CellCollection
		if ( value is CellCollection cellCollection )
		{
			_cellCollection = cellCollection;
		}

		return base.BeginEditValue( context, value );
	}

	protected override object EndEditValue( bool commitChange )
	{
		Debug.WriteLine( "CellCollectionEditor.EndEditValue" );

		if ( _row?.TableModel?.Table != null )
		{
			Debug.WriteLine( "CellCollectionEditor.EndEditValue > Update Table" );

			_row.TableModel.Table.PerformLayout( );
			_row.TableModel.Table.Refresh( );
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
	/// Creates a new instance of the specified collection item type
	/// </summary>
	/// <param name="itemType">The type of item to create</param>
	/// <returns>A new instance of the specified object</returns>
	protected override object CreateInstance( Type itemType )
	{
		Debug.WriteLine( "CellCollectionEditor.CreateInstance" );

		var cell = ( Cell ) base.CreateInstance( itemType );

		_cellCollection?.Add( cell );

		return cell;
	}
}