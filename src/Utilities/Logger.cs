namespace Utilities;

public static class Logger
{
	public static void Log( string message )
	{
		File.AppendAllLines( @".\debug.log", new[ ]
		{
			$"{DateTime.Now:hh:mm:ss} - {message}",
		} );
	}
}