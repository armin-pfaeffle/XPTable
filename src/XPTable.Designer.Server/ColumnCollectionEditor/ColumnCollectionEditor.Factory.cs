using Microsoft.DotNet.DesignTools.Editors;
using Utilities;
using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Server.ColumnCollectionEditor;

public partial class ColumnCollectionEditor
{
	[ExportCollectionEditorFactory( CollectionEditorNames.ColumnCollectionEditor )]
	private class Factory : CollectionEditorFactory<ColumnCollectionEditor>
	{
		protected override ColumnCollectionEditor CreateCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		{
			Logger.Log( "ColumnCollectionEditor.Factory.CreateCollectionEditor" );
			return new ColumnCollectionEditor( serviceProvider, collectionType );
		}
	}
}
