using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game{

	//author: Rasmus Bäckerhall
	public class MainGame{
		
		private GameEngine engine;
		private ContentObserver contentObserver;
		private EntityObserver entityObserver;

		public MainGame(){
			
			engine = new GameEngine();
			LoadContent ();
			engine.Run();
		}

		//Loads the content to game engine. Most instances will be moved to the menu classes in iteration 3
		private void LoadContent()
		{
			//TODO: Add Menus
			//MenuController menuController = new MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());

			GameContent contentManager = new GameContent();

			//Defines all keybinds
			List<KeyBind> keybinds = new List<KeyBind> ();
			keybinds = contentManager.DefineKeybindingSetup1 ("player1");
			keybinds.AddRange(contentManager.DefineKeybindSetup2 ("player2"));
			keybinds.AddRange (contentManager.DefineKeybindingForGamePad ("player3"));

			//Sends the keybinds to the engine
			foreach (KeyBind keybind in keybinds) {
				engine.KeyBind.Add (keybind);
			}
			engine.ContentNames = contentManager.LoadGameContent ();

			//The players will be defined in a menu
			Player player1 = new Player ("player1", false, 0, 0, 72, 62, 0, new BoundingBox(new Vector3(0- (72/2), 0 - (62/2) ,0), new Vector3( 0 +(72/2), 0 + (62/2) ,0)), 1, null, true);
			Player player2 = new Player ("player2", false, 400, 200, 72, 62, 0, new BoundingBox (new Vector3(400 - (72/2), 200 -(62/2),0), new Vector3(400 + (72/2), 200 + (62/2),0)), 1, null, true);
			Player player3 = new Player ("player3", true, 400, 0, 72, 62, 0, new BoundingBox(new Vector3(400-(72/2),0 + (62/2),0) , new Vector3(400-(62/2),0 +(62/2),0)), 1, null, true);

			//Adds the players to engine
			engine.Entities.Add (player1);
			engine.Entities.Add (player2);
			engine.Entities.Add (player3);

			//Creates observers
			entityObserver = new EntityObserver (engine);
			contentObserver = new ContentObserver (engine, entityObserver);

			//Adds the players to observers for modification
			contentObserver.Players.Add (player1);
			contentObserver.Players.Add (player2);
			contentObserver.Players.Add (player3);
			entityObserver.Players.Add (player1);
			entityObserver.Players.Add (player2);
			entityObserver.Players.Add (player3);

			//Subscribes the observers to the engine and sends a disposable to the observers.
			IDisposable dis = engine.Subscribe (entityObserver);
			entityObserver.AddDisposableObserver(dis);
			dis = engine.Subscribe (contentObserver);
			contentObserver.AddDisposableObserver (dis);
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}