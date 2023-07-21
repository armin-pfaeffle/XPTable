using Microsoft.DotNet.DesignTools.Serialization;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using XPTable.Models;

namespace XPTable.Designer.Server;

/// <summary>
/// Like a normal CodeDomSerializer, but generates an assignment of the column's name property.
/// </summary>
internal class ColumnCodeDomSerializer : CodeDomSerializer
{
	/// <summary>
	/// Deserializes the specified serialized CodeDOM object into an object.
	/// </summary>
	/// <param name="manager">A serialization manager interface that is used during the deserialization process.</param>
	/// <param name="codeObject">A serialized CodeDOM object to deserialize.</param>
	/// <returns>The deserialized CodeDOM object.</returns>
	/// <exception cref="T:System.ArgumentNullException">
	/// 	<paramref name="manager"/> or <paramref name="codeObject"/> is null.
	/// </exception>
	/// <exception cref="T:System.ArgumentException">
	/// 	<paramref name="codeObject"/> is an unsupported code element.
	/// </exception>
	public override object Deserialize( IDesignerSerializationManager manager, object codeObject )
	{
		// This is how we associate the component with the serializer.
		CodeDomSerializer baseClassSerializer = ( CodeDomSerializer ) manager.GetSerializer( typeof( Column ).BaseType, typeof( CodeDomSerializer ) );

		/* This is the simplest case, in which the class just calls the base class
			to do the work. */
		return baseClassSerializer.Deserialize( manager, codeObject );
	}

	/// <summary>
	/// Serializes the specified object into a CodeDOM object.
	/// </summary>
	/// <param name="manager">The serialization manager to use during serialization.</param>
	/// <param name="value">The object to serialize.</param>
	/// <returns>
	/// A CodeDOM object representing the object that has been serialized.
	/// </returns>
	/// <exception cref="T:System.ArgumentNullException">
	/// 	<paramref name="manager"/> or <paramref name="value"/> is null.
	/// </exception>
	public override object Serialize( IDesignerSerializationManager manager, object value )
	{
		/* Associate the component with the serializer in the same manner as with
			Deserialize */
		var baseClassSerializer = ( CodeDomSerializer ) manager.GetSerializer( typeof( Column ).BaseType, typeof( CodeDomSerializer ) );

		var codeObject = baseClassSerializer.Serialize( manager, value );

		/* Anything could be in the codeObject.  This sample operates on a
			CodeStatementCollection. */
		if ( codeObject is CodeStatementCollection codeStatementCollection )
		{
			var objectName = manager.GetName( value );
			CodeAssignStatement assignName = new CodeAssignStatement(
				new CodePropertyReferenceExpression(
					new CodeFieldReferenceExpression( new CodeThisReferenceExpression( ), objectName ),
					"Name" ),
				new CodePrimitiveExpression( objectName ) );

			codeStatementCollection.Add( assignName );
		}

		return codeObject;
	}
}