using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Client.TypeEditors;

public class ColumnCollectionEditor : BaseCollectionEditor
{
	/// <summary>
	/// Object constructor.
	/// </summary>
	/// <param name="type">Column type.</param>
	public ColumnCollectionEditor( Type type )
		: base( type )
	{
	}

	protected override string Name => CollectionEditorNames.ColumnCollectionEditor;
}