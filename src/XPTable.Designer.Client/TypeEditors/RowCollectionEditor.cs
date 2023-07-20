using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Client.TypeEditors;

public class RowCollectionEditor : BaseCollectionEditor
{
	/// <summary>
	/// Object constructor.
	/// </summary>
	/// <param name="type">Row type.</param>
	public RowCollectionEditor( Type type )
		: base( type )
	{
	}

	protected override string Name => CollectionEditorNames.RowCollectionEditor;
}