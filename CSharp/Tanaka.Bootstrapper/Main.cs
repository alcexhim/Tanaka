using System;

using Caltron;

namespace Tanaka.Bootstrapper
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Get the game application
			Game[] games = Game.GetAvailableGames();
			Game game = null;
			if (games.Length > 0)
			{
				game = games[0];
			}
			
			// Initialize the Caltron application
			Application.Initialize (ref args);
			
			// Create our main window for rendering
			GameWindow window = new GameWindow(game);
			window.Show ();
			window.FullScreen = true;
			
			if (game != null)
			{
				// Start the game loop
				game.Run();
			}
			else
			{
				// Start the engine loop
				Application.Start();
			}
		}
	}
}
