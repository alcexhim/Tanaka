using System;

using Caltron;
using Caltron.Input.Keyboard;

using UniversalEditor;

namespace Tanaka.Bootstrapper
{
	public class GameWindow : Window
	{
		private Game mvarGame = null;
		public GameWindow (Game game)
		{
			mvarGame = game;
		}
		
		private bool keyF = false;
		
		protected override void OnKeyDown (KeyboardEventArgs e)
		{
			base.OnKeyDown (e);
			if (e.Keys == KeyboardKey.X)
			{
				Caltron.Application.Stop ();
			}
		}
		
		protected override void OnAfterRender (RenderEventArgs e)
		{
			base.OnAfterRender (e);
			if (mvarGame == null)
			{
				e.Canvas.Clear (Colors.Red);
				e.Canvas.DrawImage ((Width - 640) / 2, (Height - 240) / 2, 640, 240, "GP404.tga");
			}
		}
	}
}

