using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game{

	public class MainGame{
		
		private GameEngine engine;
		private ContentObserver contentObserver;
		private EntityObserver entityObserver;

		public MainGame(){
			
			engine = new GameEngine();
			LoadContent ();
			engine.Run();
		}

		private void LoadContent()
		{
			List<KeyBind> keybinds = new List<KeyBind> ();
			//MenuController menuController = new MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());
			GameContent contentManager = new GameContent();
			keybinds = contentManager.DefineKeybindingSetup1 ("player1");
			keybinds.AddRange(contentManager.DefineKeybindSetup2 ("player2"));
			foreach (KeyBind keybind in keybinds) {
				engine.KeyBind.Add (keybind);
			}
			engine.ContentNames = contentManager.LoadGameContent ();

			Player player1 = new Player (1, "player");
			Player player2 = new Player (2, "player");

			engine.Entities.Add (new ActorEntity(player1.Name + player1.ID, 0, 0, 72, 62, 0, new BoundingBox(), 1, null, true));
			engine.Entities.Add (new ActorEntity (player2.Name + player2.ID, 150, 150, 72, 62, 0, new BoundingBox (), 1, null, true));

			entityObserver = new EntityObserver (engine);
			contentObserver = new ContentObserver (engine, entityObserver);

			contentObserver.Players.Add (player1);
			contentObserver.Players.Add (player2);
			entityObserver.Players.Add (player1);
			entityObserver.Players.Add (player2);

			IDisposable dis = engine.Subscribe (entityObserver);
			entityObserver.AddDisposableOBserver(dis);
			dis = engine.Subscribe (contentObserver);
			contentObserver.AddDisposableOBserver (dis);
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}