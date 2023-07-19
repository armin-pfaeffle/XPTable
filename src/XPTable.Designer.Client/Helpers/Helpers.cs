using System.Windows.Forms;

namespace XPTable.Designer.Client.Helpers;

public static class Helpers
{
    /// <summary>
    /// Returns the collection form property grid.
    /// </summary>
    /// <param name="controls"></param>
    /// <returns></returns>
    public static PropertyGrid? GetPropertyGrid( Control.ControlCollection? controls )
    {
        if ( controls is null )
            return null;

        foreach ( Control control in controls )
        {
            if ( control is PropertyGrid propertyGrid )
            {
                return ( propertyGrid );
            }

            if ( control.Controls.Count > 0 )
            {
                var grid = GetPropertyGrid( control.Controls );
                if ( grid is not null )
                {
                    return grid;
                }
            }
        }

        return null;
    }
}