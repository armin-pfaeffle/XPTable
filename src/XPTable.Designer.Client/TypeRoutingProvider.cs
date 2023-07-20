using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Diagnostics;
using XPTable.Designer.Client.TypeEditors;
using XPTable.Designer.ClientServerProtocol;

namespace XPTable.Designer.Client;

[ExportTypeRoutingDefinitionProvider]
internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
{
	public override IEnumerable<TypeRoutingDefinition> GetDefinitions( )
	{
		Debug.WriteLine( "TypeRoutingProvider.GetDefinitions" );

		return new[ ]
		{
			new TypeRoutingDefinition( TypeRoutingKinds.Editor, CollectionEditorNames.CellCollectionEditor, typeof( CellCollectionEditor ) ),
			new TypeRoutingDefinition( TypeRoutingKinds.Editor, CollectionEditorNames.ColumnCollectionEditor, typeof( ColumnCollectionEditor ) ),
			new TypeRoutingDefinition( TypeRoutingKinds.Editor, CollectionEditorNames.RowCollectionEditor, typeof( RowCollectionEditor ) ),
		};
	}
}