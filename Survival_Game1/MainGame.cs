using System;
using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game{

	public class MainGame{
		
		private GameEngine engine;

		public MainGame(){
			
			engine = new GameEngine();
			ObjectObserver observer = new ObjectObserver (engine);
			IDisposable dis = engine.Subscribe (observer);
			observer.AddDisposableOBserver(dis);
			LoadContent ();
			engine.Run();
		}

		private void LoadContent()
		{
			List<string> content = new List<string> ();
			List<KeyBind> keybinds = new List<KeyBind> ();
			//MenuController menuController = new MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());
			GameContent contentManager = new GameContent();
			content = contentManager.LoadGameContent ();
			keybinds = contentManager.DefineKeybindingSetup1 ("player1");
			foreach (KeyBind keybind in keybinds) {
				engine.KeyBind.Add (keybind);
			}
			engine.ContentNames = contentManager.LoadGameContent ();
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}