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
		int tileNO = 1;

		int numberOfPlayers = 2;
		Viewport defaultview;
		Viewport rightview;
		Viewport leftview;
		Viewport topView;
		Viewport topLeftView;
		Viewport topRightView;

		static int TILE_WIDTH = 50;
		static int TILE_HEIGHT = 50;

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

			GameContent contentManager = new GameContent ();

			//Defines all keybindings
			List<KeyBind> keybinds = new List<KeyBind> ();
			keybinds = contentManager.DefineKeybindingsSetup1 ("player1");
			keybinds.AddRange (contentManager.DefineKeybindingsSetup2 ("player2"));
			keybinds.AddRange (contentManager.DefineKeybindingsForGamePad ("player3"));

			//Sends the keybindings to the engine
			foreach (KeyBind keybind in keybinds) {
				engine.KeyBind.Add (keybind);
			}
			engine.ContentNames = contentManager.LoadGameContent ();
			engine.SoundContentNames = contentManager.LoadSoundContent ();

			BoundingBox tmpPortion = new BoundingBox (new Vector3 (0, 0, 0),
				                         new Vector3 (engine.GraphicsDevice.Viewport.Width, engine.GraphicsDevice.Viewport.Height, 0));
			this.GenerateTiles (tmpPortion);

			Player player1 = new Player ("player1", false, 100, 100, 72, 62, 0,
				                 new BoundingBox (new Vector3 (100 - (72 / 4), 100 - (62 / 4), 0),
					                 new Vector3 (100 + (72 / 4), 100 + (62 / 4), 0)), 1, null, true);
			Player player2 = new Player ("player2", false, 400, 200, 72, 62, 0,
				                 new BoundingBox (new Vector3 (400 - (72 / 4), 200 - (62 / 4), 0),
					                 new Vector3 (400 + (72 / 4), 200 + (62 / 4), 0)), 1, null, true);
			Player player3 = new Player ("player3", false, 500, 400, 72, 62, 0,
				                 new BoundingBox (new Vector3 (500 - (72 / 4), 400 - (62 / 4), 0),
					                 new Vector3 (500 + (72 / 4), 400 + (62 / 4), 0)), 1, null, true);

			//Adds the players to engine
			engine.Entities.Add (player1);
			engine.Entities.Add (player2);
			engine.Entities.Add (player3);

			//Creates observers
			entityObserver = new EntityObserver (engine);
			contentObserver = new ContentObserver (engine, entityObserver);

			//Subscribes the observers to the engine and sends a disposable to the observers.
			IDisposable dis = engine.Subscribe (entityObserver);
			entityObserver.AddDisposableObserver (dis);
			dis = engine.Subscribe (contentObserver);
			contentObserver.AddDisposableObserver (dis);

		

			if(numberOfPlayers == 3) {
				defaultview = engine.GraphicsDevice.Viewport;
				leftview = defaultview;
				rightview = defaultview;
				topView = defaultview;

				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;
				leftview.Y = leftview.Height / 2;
				rightview.Y = leftview.Y;
				topView.Height = leftview.Y;
				rightview.Height = rightview.Y;
				leftview.Height = leftview.Y;

				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player2.X - leftview.Width / 2, player2.Y - leftview.Height / 2, 0), leftview, player2));
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player3.X - rightview.Width / 2, player3.Y - rightview.Height / 2, 0), rightview, player3));
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - topView.Width / 2, player1.Y - topView.Height / 2, 0), topView, player1));
			} 

			if (numberOfPlayers == 1) {
				defaultview = engine.GraphicsDevice.Viewport;

				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - defaultview.Width / 2, player1.Y - defaultview.Height / 2, 0), defaultview, player1));
			}

			if (numberOfPlayers == 2) {
				defaultview = engine.GraphicsDevice.Viewport;
				leftview = defaultview;
				rightview = defaultview;

				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;

				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player2.X - leftview.Width / 2, player2.Y - leftview.Height / 2, 0), leftview, player2));
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - rightview.Width / 2, player1.Y - rightview.Height / 2, 0), rightview, player1));
			}

			if(numberOfPlayers == 4) {

				defaultview = engine.GraphicsDevice.Viewport;
				leftview = defaultview;
				rightview = defaultview;
				topView = defaultview;

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
				
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player2.X - leftview.Width / 2, player2.Y - leftview.Height / 2, 0), leftview, player2));
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player3.X - rightview.Width / 2, player3.Y - rightview.Height / 2, 0), rightview, player3));
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player1.X - topLeftView.Width / 2, player1.Y - topLeftView.Height / 2, 0), topLeftView, player1));
				engine.Viewposes.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player3.X - topRightView.Width / 2, player3.Y - topRightView.Height / 2, 0), topRightView, player3));
			}

		}

		//Generates terrain in a certain portion of the world.
		public void GenerateTiles(BoundingBox portion){
			Tile curTile;
			BoundingBox curTileBox;
			float curX = portion.Min.X;
			float curY = portion.Min.Y;

			while(curY <= portion.Max.Y){
				while(curX <= portion.Max.X) {
					curTileBox = new BoundingBox();
					curTile = new Tile("tile" + tileNO, curX, curY, TILE_WIDTH, TILE_HEIGHT,
						0, curTileBox, 0, null, false);
					engine.Entities.Add(curTile);

					tileNO++;
					curX += TILE_WIDTH;
				}
				curX = 0;
				curY += TILE_HEIGHT;
			}
			// TODO: Save portion to already generated list.
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}
