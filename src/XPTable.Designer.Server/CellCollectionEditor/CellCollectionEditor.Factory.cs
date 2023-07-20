using Microsoft.DotNet.DesignTools.Editors;
using System.Diagnostics;
using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Server.CellCollectionEditor;

public partial class CellCollectionEditor
{
	[ExportCollectionEditorFactory( CollectionEditorNames.CellCollectionEditor )]
	private class Factory : CollectionEditorFactory<CellCollectionEditor>
	{
		protected override CellCollectionEditor CreateCollectionEditor( IServiceProvider serviceProvider, Type collectionType )
		{
			Debug.WriteLine( "CellCollectionEditor.Factory.CreateCollectionEditor" );

			return new CellCollectionEditor( serviceProvider, collectionType );
		}
	}
}