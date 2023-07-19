using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;
using Utilities;
using XPTable.Designer.Client.TypeEditors;

namespace XPTable.Designer.Client;

// TODO: Relevant?
[ExportTypeRoutingDefinitionProvider]
internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
{
	public override IEnumerable<TypeRoutingDefinition> GetDefinitions( )
	{
		Logger.Log( "TypeRoutingProvider.GetDefinitions" );
		
		return new[ ]
		{
			new TypeRoutingDefinition( TypeRoutingKinds.Editor, nameof( ColumnCollectionEditor ), typeof( ColumnCollectionEditor ) ),
		};
	}
}
