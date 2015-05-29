using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game{

	//author: Rasmus Bäckerhall
	public class MainGame{
		private GameEngine engine;
		private ContentObserver contentObserver;
		private EntityObserver entityObserver;
		private SoundEntity backgroundSound;
		private GameContent contentManager = new GameContent();
		private GameState currentState;
		List<Portion> generatedPortions = new List<Portion>();

		int numberOfPlayers = 2;
		Viewport defaultview;
		Viewport rightview;
		Viewport leftview;
		Viewport topView;
		Viewport topLeftView;
		Viewport topRightView;

		public MainGame(){
			currentState = GameState.StartMenu;
			engine = new GameEngine(0);
			LoadContent();
			engine.Run();
		}

		//Loads the content to game engine. Most instances will be moved to the menu classes in iteration 3
		private void LoadContent()
		{
			//engine.ContentNames = contentManager.LoadContent ("Content/");
			engine.ContentNames = contentManager.LoadGameContent ();
			engine.SoundContentNames = contentManager.LoadContent ("Content/Sound/");

			//Creates observers
			entityObserver = new EntityObserver (engine, generatedPortions);
			contentObserver = new ContentObserver (engine, entityObserver);

			//Subscribes the observers to the engine and sends a disposable to the observers.
			IDisposable dis = engine.Subscribe (entityObserver);
			entityObserver.AddDisposableObserver (dis);
			dis = engine.Subscribe (contentObserver);
			contentObserver.AddDisposableObserver (dis);

			engine.KeyBind.AddRange (contentManager.MenuKeyBindSetup ());

			PlayGameMenu gameMenu = new PlayGameMenu (engine);

			//gameMenu.createMenu ();
			//StartMenu startMenu = new StartMenu ("blabla");
			//OptionMenu optionMenu = new OptionMenu ();
			//MenuController menuController = new MenuController (startMenu, optionMenu, gameMenu);

			StartMenu startMenu = new StartMenu (engine);
			OptionMenu optionMenu = new OptionMenu (engine);
			//MenuController menuController = new MenuController (startMenu, optionMenu, gameMenu, ref currentState, engine);

			LoadGame ();
		}

		private void LoadGame(){
			backgroundSound = new SoundEntity (2.0F, 10.0F);
			//TODO: Add Menus
			//MenuController menuController = new MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());

			//Defines all keybindings
			List<KeyBind> keybinds = new List<KeyBind> ();
			keybinds = contentManager.DefineKeybindingsSetup1 ("player1");
			keybinds.AddRange (contentManager.DefineKeybindingsSetup2 ("player2"));
			keybinds.AddRange (contentManager.DefineKeybindingsForGamePad ("player3"));
			//Sends the keybindings to the engine
			foreach (KeyBind keybind in keybinds) {
				engine.KeyBind.Add (keybind);
			}

			BoundingBox portionBounds = new BoundingBox(new Vector3(0, 0, 0),
				new Vector3(Portion.PORTION_WIDTH, Portion.PORTION_HEIGHT, 0));
			Portion portion = new Portion(portionBounds);
			portion.AddPortion(generatedPortions, engine.Entities);

			Player player1 = new Player ("player1", false, engine.GraphicsDevice.Viewport.Width / 2,
				engine.GraphicsDevice.Viewport.Height / 2, 72, 62, 0,
				new BoundingBox (new Vector3 (engine.GraphicsDevice.Viewport.Width / 2 - (72 / 4),
					engine.GraphicsDevice.Viewport.Height / 2 - (62 / 4), 0),
					new Vector3 (engine.GraphicsDevice.Viewport.Width / 2 + (72 / 4),
						engine.GraphicsDevice.Viewport.Height / 2 + (62 / 4), 0)), 1, null, true);
			Player player2 = new Player ("player2", false, 500, 200, 72, 62, 0,
				                 new BoundingBox (new Vector3 (500 - (72 / 4), 300 - (62 / 4), 0),
					                 new Vector3 (500 + (72 / 4), 300 + (62 / 4), 0)), 1, null, true);
			Player player3 = new Player ("player3", false, 500, 400, 72, 62, 0,
				new BoundingBox (new Vector3 (500 - (72 / 4), 400 - (62 / 4), 0),
					new Vector3 (500 + (72 / 4), 400 + (62 / 4), 0)), 1, null, true);

			//Adds the players to engine
			//engine.Entities.Add (player1);
			//engine.Entities.Add (player2);
			//engine.Entities.Add (player3);

			defaultview = engine.GraphicsDevice.Viewport;
			leftview = defaultview;
			rightview = defaultview;
			topView = defaultview;
			topLeftView = defaultview;
			topRightView = defaultview;


			if (numberOfPlayers == 1) {
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity>
					(new Vector3 (player1.X - defaultview.Width / 2,
						player1.Y - defaultview.Height / 2, 0), defaultview, player1));
				
				engine.AddEntity (player1);
			}

			if (numberOfPlayers == 2) {
				
				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;

				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player2.X - leftview.Width / 2, player2.Y - leftview.Height / 2, 0), leftview, player2));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - rightview.Width / 2, player1.Y - rightview.Height / 2, 0), rightview, player1));

				engine.AddEntity (player1);
				engine.AddEntity (player2);
			}

			if(numberOfPlayers == 3) {

				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;
				leftview.Y = leftview.Height / 2;
				rightview.Y = leftview.Y;
				topView.Height = leftview.Y;
				rightview.Height = rightview.Y;
				leftview.Height = leftview.Y;

				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player2.X - leftview.Width / 2, player2.Y - leftview.Height / 2, 0), leftview, player2));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player3.X - rightview.Width / 2, player3.Y - rightview.Height / 2, 0), rightview, player3));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - topView.Width / 2, player1.Y - topView.Height / 2, 0), topView, player1));

				engine.AddEntity (player1);
				engine.AddEntity (player2);
				engine.AddEntity (player3);
			}
				
			if(numberOfPlayers == 4) {

				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;
				leftview.Y = leftview.Height / 2;
				rightview.Y = leftview.Y;
				rightview.Height = rightview.Y;
				leftview.Height = leftview.Y;
				topLeftView.Height = leftview.Y;
				topRightView.Height = leftview.Y;
				topLeftView.Width = leftview.Width;				
				topRightView.Width = topLeftView.Width;
				topRightView.X = topLeftView.Width;

				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player2.X - leftview.Width / 2, player2.Y - leftview.Height / 2, 0), leftview, player2));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player3.X - rightview.Width / 2, player3.Y - rightview.Height / 2, 0), rightview, player3));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - topLeftView.Width / 2, player1.Y - topLeftView.Height / 2, 0), topLeftView, player1));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player3.X - topRightView.Width / 2, player3.Y - topRightView.Height / 2, 0), topRightView, player3));
			
				engine.AddEntity (player1);
				engine.AddEntity (player2);
				engine.AddEntity (player3);
			}
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}
