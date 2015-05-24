using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game{

	//author: Rasmus Bäckerhall
	public class MainGame{
		private GameEngine engine;
		private PlayGameMenu menu;

		public MainGame(){
			engine = new GameEngine();
			menu = new PlayGameMenu(engine);
			menu.LoadGame();
			//LoadContent ();
			engine.Run();
		}

		//Loads the content to game engine. Most instances will be moved to the menu classes in iteration 3
		private void LoadContent()
		{
			throw new NotImplementedException();

		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}
