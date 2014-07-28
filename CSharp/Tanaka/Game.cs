using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tanaka
{
	public abstract class Game
	{
		protected virtual void Create()
		{
		}
		protected virtual void Destroy()
		{
		}
		
		public void Run()
		{
			Console.WriteLine ("tanaka: creating game");
			Create ();
			Console.WriteLine ("tanaka: running game");
			Caltron.Application.Start ();
			Console.WriteLine ("tanaka: destroying game");
			Destroy ();
		}
		
		public static Game[] GetAvailableGames()
		{
			List<Game> list = new List<Game>();
			string[] asmfiles = System.IO.Directory.GetFiles (System.IO.Path.GetDirectoryName (System.Reflection.Assembly.GetExecutingAssembly ().Location), "*.dll", System.IO.SearchOption.TopDirectoryOnly);
			foreach (string asmfile in asmfiles)
			{
				try
				{
					Assembly asm = Assembly.LoadFile(asmfile);
					Type[] types = null;
					try
					{
						types = asm.GetTypes ();
					}
					catch (ReflectionTypeLoadException ex)
					{
						types = ex.Types;
					}
					foreach (Type type in types)
					{
						if (type.IsSubclassOf (typeof(Game)))
						{
							list.Add((Game)type.Assembly.CreateInstance (type.FullName));
						}
					}
				}
				catch
				{
				}
			}
			return list.ToArray ();
		}
	}
}

