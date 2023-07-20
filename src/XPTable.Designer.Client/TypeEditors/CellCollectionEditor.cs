using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Client.TypeEditors;

public class CellCollectionEditor : BaseCollectionEditor
{
	/// <summary>
	/// Object constructor.
	/// </summary>
	/// <param name="type">Cell type.</param>
	public CellCollectionEditor( Type type )
		: base( type )
	{
	}

	protected override string Name => CollectionEditorNames.CellCollectionEditor;
}