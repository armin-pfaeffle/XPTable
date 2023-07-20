namespace XPTable.Designer.Client.Extensions;

public static class ControlCollectionExtensions
{
	/// <summary>
	/// Returns the collection form property grid.
	/// </summary>
	/// <param name="controls">List of controls which to be searched</param>
	/// <returns>First PropertyGrid found</returns>
	public static PropertyGrid? GetPropertyGrid( this Control.ControlCollection? controls )
	{
		if ( controls is null )
		{
			return null;
		}

		foreach ( Control control in controls )
		{
			if ( control is PropertyGrid propertyGrid )
			{
				return propertyGrid;
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

	/// <summary>
	/// Returns a list of buttons which are in given control list or it's sub controls.
	/// </summary>
	/// <param name="controls">List of controls which to be searched</param>
	/// <returns>List of buttons</returns>
	public static IEnumerable<Button> GetButtons( this Control.ControlCollection? controls )
	{
		var result = new List<Button>( );

		if ( controls == null )
		{
			return result;
		}

		foreach ( Control control in controls )
		{
			if ( control is Button button )
			{
				result.Add( button );
			}

			if ( control.Controls.Count > 0 )
			{
				result.AddRange( control.Controls.GetButtons( ) );
			}
		}

		return result;
	}
}