using System.Reflection;

namespace XPTable.Designer.Client.Extensions;

internal static class Extensions
{
    public static object? GetPropValue( this object source, string propertyName )
    {
        return source.GetType( ).GetRuntimeProperty( propertyName )?.GetValue( source );
    }
}