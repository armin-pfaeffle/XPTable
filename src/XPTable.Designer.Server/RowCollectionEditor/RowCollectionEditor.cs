using Microsoft.DotNet.DesignTools.Editors;
using System.ComponentModel;
using System.Diagnostics;
using XPTable.Models;

namespace XPTable.Designer.Server.RowCollectionEditor;

public partial class RowCollectionEditor : CollectionEditor
{
	private TableModel? _tableModel = null;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="serviceProvider"></param>
	/// <param name="collectionType">The type of the collection to be edited</param>
	public RowCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		: base( serviceProvider, collectionType )
	{
		Debug.WriteLine( "RowCollectionEditor constructor" );
	}


	protected override CollectionEditorViewModel BeginEditValue( ITypeDescriptorContext context, object value )
	{
		Debug.WriteLine( $"RowCollectionEditor.BeginEditValue (value: {value.GetType( )}, context.Instance: {context.Instance.GetType( )})" );

		if ( context.Instance is TableModel columnModel )
		{
			_tableModel = columnModel;
		}
		// This must be a sub row
		else if (context.Instance is Row )
		{
			_tableModel = ( ( Row ) context.Instance ).TableModel;
		}

		// Store access to RowCollection
		// Note: Not needed ATM
		// _rowCollection = ( RowCollection ) value;

		return base.BeginEditValue( context, value );
	}

	protected override object EndEditValue( bool commitChange )
	{
		Debug.WriteLine( "RowCollectionEditor.EndEditValue" );

		if ( _tableModel?.Table != null )
		{
			Debug.WriteLine( "RowCollectionEditor.EndEditValue > Update Table" );
			
			_tableModel.Table.PerformLayout( );
			_tableModel.Table.Refresh( );
		}

		return base.EndEditValue( commitChange );
	}

	// TODO: Remove due to no custom code?
	protected override object SetItems( object editValue, object[ ] value )
	{
		Debug.WriteLine( "RowCollectionEditor.SetItems" );

		var newCollection = base.SetItems( editValue, value );

		return newCollection;
	}

	/// <summary>
	/// Creates a new instance of the specified collection item type
	/// </summary>
	/// <param name="itemType">The type of item to create</param>
	/// <returns>A new instance of the specified object</returns>
	protected override object CreateInstance( Type itemType )
	{
		Debug.WriteLine( "RowCollectionEditor.CreateInstance" );

		var row = ( Row ) base.CreateInstance( itemType );

		return row;
	}
}