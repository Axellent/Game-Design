using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game{

	//author: Rasmus Bäckerhall
	public class MainGame{
		public static GameState currentState;

		private GameEngine engine;
		private ContentObserver contentObserver;
		private EntityObserver entityObserver;
		private SoundEntity backgroundSound;
		private GameContent contentManager = new GameContent();
		List<Portion> generatedPortions = new List<Portion>();
		private List<Tuple<string, bool>> numPlayers = new List<Tuple<string, bool>> ();
		private List<Player> players = new List<Player>();

		Viewport defaultview;
		Viewport rightview;
		Viewport leftview;
		Viewport topView;
		Viewport topLeftView;
		Viewport topRightView;

		public MainGame(){
			currentState = GameState.StartMenu;
			engine = new GameEngine();
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
			contentObserver = new ContentObserver (engine);

			//Subscribes the observers to the engine and sends a disposable to the observers.
			IDisposable dis = engine.Subscribe (entityObserver);
			entityObserver.AddDisposableObserver (dis);
			dis = engine.Subscribe (contentObserver);
			contentObserver.AddDisposableObserver (dis);

			engine.KeyBind.AddRange (contentManager.MenuKeyBindSetup ());

			PlayGameMenu playGameMenu = new PlayGameMenu (engine);
			playGameMenu.AddPlayBtnListener (LoadGame);
			playGameMenu.AddPlayerBtnsListeners (AddPlayer);
			StartMenu startMenu = new StartMenu (engine);
			OptionMenu optionMenu = new OptionMenu (engine);
			MenuController menuController = new MenuController (startMenu, optionMenu, playGameMenu, ref currentState, engine);
		}

		private void AddPlayer(EventArgs e){
			numPlayers.Add(new Tuple<string, bool>(((PlayerNameEventArgs)e).PlayerName, ((PlayerNameEventArgs)e).IsController));
		}

		private void LoadGame(EventArgs e){
			engine.ClearEntities ();
			engine.ClearViewPositions ();
			currentState = GameState.Game;
			backgroundSound = new SoundEntity (2.0F, 10.0F);
			//TODO: Add Menus
			//MenuController menuController = new MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());

			//Defines all keybindings
			InitializeKeyBinds();

			BoundingBox portionBounds = new BoundingBox(new Vector3(0, 0, 0),
				new Vector3(Portion.PORTION_WIDTH, Portion.PORTION_HEIGHT, 0));
			Portion portion = new Portion(portionBounds);
			portion.AddPortion(generatedPortions, engine.Entities);

			InitializePlayers();
			InitializeViewports ();
		}

		public void InitializeKeyBinds(){
			List<KeyBind<Keys>> keybinds = new List<KeyBind<Keys>> ();
			List<KeyBind<Buttons>> buttonBinds = new List<KeyBind<Buttons>> ();
			int numControllers = 0;
			for (int i = 0; i < numPlayers.Count; i++) {
				if (!numPlayers [i].Item2) {
					if (numPlayers [i].Item1.Equals ("player1")) {
						engine.KeyBind.AddRange (contentManager.DefineKeybindingsSetup1 (numPlayers [i].Item1));
					} else if (numPlayers [i].Item1.Equals ("player2")) {
						engine.KeyBind.AddRange (contentManager.DefineKeybindingsSetup2 (numPlayers [i].Item1));
					}
				} else {
					numControllers++;
					engine.ButtonBinds.AddRange (contentManager.DefineKeybindingsForGamePad (numPlayers [i].Item1, numControllers));
				}
			}
			engine.SetNumberOfControllers (numControllers);
			//Sends the keybindings to the engine
		}

		public void InitializeViewports(){
			defaultview = engine.GraphicsDevice.Viewport;
			leftview = defaultview;
			rightview = defaultview;
			topView = defaultview;
			topLeftView = defaultview;
			topRightView = defaultview;

			if (numPlayers.Count == 1) {
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity>
					(new Vector3 (players[0].X - defaultview.Width / 2,
						players[0].Y - defaultview.Height / 2, 0), defaultview, players[0]));

				initPortions(players[0]);

				engine.AddEntity (players[0]);
			}

			if (numPlayers.Count == 2) {

				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;

				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[0].X - leftview.Width / 2, players[0].Y - leftview.Height / 2, 0), leftview, players[0]));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[1].X - rightview.Width / 2, players[1].Y - rightview.Height / 2, 0), rightview, players[1]));

				initPortions(players[0]);
				initPortions(players[1]);

				engine.AddEntity (players[0]);
				engine.AddEntity (players[1]);
			}

			if(numPlayers.Count == 3) {

				leftview.Width = leftview.Width / 2;
				rightview.Width = rightview.Width / 2;
				rightview.X = leftview.Width;
				leftview.Y = leftview.Height / 2;
				rightview.Y = leftview.Y;
				topView.Height = leftview.Y;
				rightview.Height = rightview.Y;
				leftview.Height = leftview.Y;

				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[1].X - leftview.Width / 2, players[1].Y - leftview.Height / 2, 0), leftview, players[1]));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[2].X - rightview.Width / 2, players[2].Y - rightview.Height / 2, 0), rightview, players[2]));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[0].X - topView.Width / 2, players[0].Y - topView.Height / 2, 0), topView, players[0]));

				initPortions(players[0]);
				initPortions(players[1]);
				initPortions(players[2]);

				engine.AddEntity (players[0]);
				engine.AddEntity (players[1]);
				engine.AddEntity (players[2]);
			}

			if(numPlayers.Count == 4) {

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

				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[2].X - leftview.Width / 2, players[2].Y - leftview.Height / 2, 0), leftview, players[2]));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[3].X - rightview.Width / 2, players[3].Y - rightview.Height / 2, 0), rightview, players[3]));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[0].X - topLeftView.Width / 2, players[0].Y - topLeftView.Height / 2, 0), topLeftView, players[0]));
				engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (players[1].X - topRightView.Width / 2, players[1].Y - topRightView.Height / 2, 0), topRightView, players[1]));

				initPortions(players[0]);
				initPortions(players[1]);
				initPortions(players[2]);
				initPortions(players[3]);

				engine.AddEntity (players[0]);
				engine.AddEntity (players[1]);
				engine.AddEntity (players[2]);
				engine.AddEntity (players[3]);
			}
			//initPortions(player1);
		}

		/* Generates initial portions around the player. */
		public void initPortions(Player player){
			BoundingBox portionBounds = new BoundingBox(new Vector3(0, 0, 0),
				new Vector3(Portion.PORTION_WIDTH, Portion.PORTION_HEIGHT, 0));
			Portion portion = new Portion(portionBounds);
			portion.AddPortion(generatedPortions, engine.Entities);
			entityObserver.CheckPortions(player);
		}
		public void InitializePlayers(){
			for (int i = 0; i < numPlayers.Count; i++) {
				Player player = new Player (numPlayers[i].Item1, numPlayers[i].Item2, engine.GraphicsDevice.Viewport.Width / 2 + (80 * (i + 1)),
					                engine.GraphicsDevice.Viewport.Height / 2, 72, 62, 0,
					                new BoundingBox (new Vector3 (engine.GraphicsDevice.Viewport.Width / 2 - (72 / 4),
						                engine.GraphicsDevice.Viewport.Height / 2 - (62 / 4), 0),
						                new Vector3 (engine.GraphicsDevice.Viewport.Width / 2 + (72 / 4),
							                engine.GraphicsDevice.Viewport.Height / 2 + (62 / 4), 0)), 1, null, true);
				players.Add (player);
			}
		}
		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}
