using Microsoft.DotNet.DesignTools.Editors;
using System.Diagnostics;
using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Server.RowCollectionEditor;

public partial class RowCollectionEditor
{
	[ExportCollectionEditorFactory( CollectionEditorNames.RowCollectionEditor )]
	private class Factory : CollectionEditorFactory<RowCollectionEditor>
	{
		protected override RowCollectionEditor CreateCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		{
			Debug.WriteLine( "RowCollectionEditor.Factory.CreateCollectionEditor" );

			return new RowCollectionEditor( serviceProvider, collectionType );
		}
	}
}