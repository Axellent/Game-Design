using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class EntityObserver : IObserver<GameTime>
	{
		GameEngine engine;
		private float playerSpeed;
		private IDisposable removeableObserver;
		private List<Player> oldPlayers;
		List<Portion> generatedPortions;
		private bool compSet;
		TimeSpan oldtimespan;

		public EntityObserver (GameEngine engine, List<Portion> generatedPortions)
		{
			oldPlayers = new List<Player> ();
			this.engine = engine;
			this.generatedPortions = generatedPortions;
		}

		public void AddDisposableObserver(IDisposable disposableObserver){
			removeableObserver = disposableObserver;
		}

		public void Unsubscribe()
		{
			removeableObserver.Dispose();
			//players.Clear();
		}

		/* TODO: Make this class more dynamic. Either change name of the class to PlayerObserver,
		 * or make it able to change in all entities not only in player entities.
		 * 
		 */
		//Called by engine. In this method all the changes to the player is made
		//Hint: Not fully working yet, needs to be more dynamic. The collision management only works at certain key input
		public void OnNext (GameTime gameTime)
		{
			if (MainGame.currentState == GameState.Game) {
				for (int i = 0; i < engine.Entities.Count; i++) {
					if (engine.Entities [i].GetType () == typeof(Player)) {
						HandlePlayer (engine.Entities [i]);

					} 
					else if(engine.Entities[i].GetType() == typeof(Wolf)){
						Wolf wolf = (Wolf)engine.Entities[i];
						wolf.UpdateWolf();
					}
				}
			}
			else if (MainGame.currentState == GameState.InGameMenu || MainGame.currentState == GameState.OptionMenu 
				|| MainGame.currentState == GameState.PlayGameMenu || MainGame.currentState == GameState.StartMenu) {				
					if (engine.Entities.Exists(e=> e.GetType ().IsSubclassOf (typeof(MenuComponent)))) {
					TimeSpan time = gameTime.TotalGameTime;
					if (oldtimespan.Ticks == 0 || time.TotalMilliseconds - oldtimespan.TotalMilliseconds > 200) { 
						HandleMenuComponent (time);
					}
				}
				compSet = false;
			}
		}

		private void HandleMenuComponent (TimeSpan time){
			List<Entity> menuComps = engine.Entities.FindAll (e => e.GetType ().IsSubclassOf (typeof(MenuComponent)));
			KeyBind keybind = engine.Actions.Find (k => k.EntityID.Equals ("global"));
			MenuComponent menuComp = (MenuComponent)menuComps.Find (m => ((MenuComponent)m).IsHighlighted);
			if (keybind != null) {
				switch (keybind.Action) {
				case "up":
					menuComp.IsHighlighted = false;
					if (menuComps.Exists (e => ((MenuComponent)e).Order == menuComp.Order - 1)) {
						((MenuComponent)menuComps.Find (e => ((MenuComponent)e).Order == menuComp.Order - 1)).IsHighlighted = true;
					} 
					else 
						((MenuComponent)menuComps.Find (e => ((MenuComponent)e).Order == menuComps.Count - 1)).IsHighlighted = true;
					oldtimespan = time;
					break;
				case "down":
					menuComp.IsHighlighted = false;
					if (menuComps.Exists (e => ((MenuComponent)e).Order == menuComp.Order + 1)) {
						((MenuComponent)menuComps.Find (e => ((MenuComponent)e).Order == menuComp.Order + 1)).IsHighlighted = true;
					} 
					else 
						((MenuComponent)menuComps.Find (e => ((MenuComponent)e).Order == 0)).IsHighlighted = true;
					oldtimespan = time;
					break;
				case "left":
					if (menuComp.GetType () == typeof(OptionBar)) {
						HandleOptionBar ((OptionBar)menuComp, -1);
					}
					oldtimespan = time;
					break;
				case "right":
					if (menuComp.GetType () ==  typeof(OptionBar)) {
						HandleOptionBar ((OptionBar)menuComp, 1);
					}
					oldtimespan = time;
					break;
				case "enter":
					if (menuComp.GetType () == typeof(CheckBox)) {
						if (((CheckBox)menuComp).IsChecked) {
							((CheckBox)menuComp).IsChecked = false;
						} else {
							((CheckBox)menuComp).IsChecked = true;
						}
					} else if (menuComp.GetType () == typeof(Button)) {
						HandlePlayerButtons ((Button)menuComp);
					}
					oldtimespan = time;
					break;
				case "menu":
					
					break;
				}
			}
		}

		public void HandlePlayerButtons(Button button){
			switch(button.ID){
			case "player1Btn":
				if (!button.PlayerSelectedCalled)
					button.OnPlayerSelect ("player1", false);
				else
					button.PlayerSelectedCalled = false;
				break;
			case "player2Btn":
				if (!button.PlayerSelectedCalled)
					button.OnPlayerSelect ("player2", false);
				else
					button.PlayerSelectedCalled = false;
				break;
			case "player3Btn":
				if (!button.PlayerSelectedCalled)
					button.OnPlayerSelect ("player3", true);
				else
					button.PlayerSelectedCalled = false;
				break;
			case "player4Btn":
				if (!button.PlayerSelectedCalled)
					button.OnPlayerSelect ("player4", true);
				else
					button.PlayerSelectedCalled = false;
				break;
			default:
				button.OnSelect ();
				break;
			}
		}

		private void HandleOptionBar(OptionBar optionBar, int addition){
			if (addition > 0) {
				if (optionBar.TenPercentage != 10)
					optionBar.TenPercentage += addition;
			} else if (addition < 0) {
				if (optionBar.TenPercentage != 0)
					optionBar.TenPercentage += addition;
			}
		}

		private void HandlePlayer(Entity entity){
			Player player = (Player) entity;				//From here, move to a method.
			List<KeyBind> playerKeyBinds = engine.Actions.FindAll (x => x.EntityID.Equals (player.ID));
			if (playerKeyBinds.Count > 1) {
				playerSpeed = (float)Math.Sqrt (Math.Pow (player.MovementSpeed, 2) / 2);
			} else
				playerSpeed = player.MovementSpeed;
			int actionMade = 1;

			foreach (KeyBind keybind in playerKeyBinds) {
				player.IsMoving = true;

				switch (keybind.Action) {
				case "up":
					if (actionMade > 1)
						engine.ConfigureEntity (new Vector3 (player.Velocity.X, -playerSpeed, 0), (float)Math.PI - player.Rotation / 2, player.ID);
					else
						engine.ConfigureEntity (new Vector3 (0, -playerSpeed, 0), (float)Math.PI, player.ID);
					CheckPortions (player);
					break;
				case "down":
					if (actionMade > 1)
						engine.ConfigureEntity (new Vector3 (player.Velocity.X, playerSpeed, 0), player.Rotation / 2, player.ID);
					else
						engine.ConfigureEntity (new Vector3 (0, playerSpeed, 0), 0, player.ID);
					CheckPortions (player);
					break;
				case "left":
					if (actionMade > 1)
						engine.ConfigureEntity (new Vector3 (-playerSpeed, player.Velocity.Y, 0), player.Rotation / 2 + (float)Math.PI / 4, player.ID);
					else
						engine.ConfigureEntity (new Vector3 (-playerSpeed, 0, 0), (float)Math.PI / 2, player.ID);
					CheckPortions (player);
					break;
				case "right":
					if (actionMade > 1)
						engine.ConfigureEntity (new Vector3 (playerSpeed, player.Velocity.Y, 0), - player.Rotation / 2 - (float)Math.PI / 4, player.ID);
					else
						engine.ConfigureEntity (new Vector3 (playerSpeed, 0, 0), -(float)Math.PI / 2, player.ID);
					CheckPortions (player);
					break;
				case "action":
					break;
				default: 
					break;
				}
				foreach (Tuple <Vector3,Viewport, Entity> pair in engine.ViewPositions) {
					if (pair.Item3.ID.Equals (player.ID)) {
						engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (player.X - pair.Item2.Width / 2, player.Y - pair.Item2.Height / 2, 0), pair.Item2, pair.Item3));
						engine.ViewPositions.Remove (pair);
						break;
					}
				}
				actionMade++;
			}
		}

		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}

		public void OnCompleted ()
		{
			for(int i = 0; i < engine.Entities.Count; i++) {
				if(engine.Entities[i].GetType() == typeof(Player)) {
					Player player = (Player)engine.Entities[i];
					player.IsMoving = false;
					engine.MoveEntity (new Vector3(0,0,0), player.ID);
				}
			}
		}

		//Identifies which portion the player is currently in and generates new portions
		//next to the current one as necessary.
		public void CheckPortions(Player player){
			BoundingBox bounds;
			Portion curPortion = null;

			for(int i = 0; i < generatedPortions.Count; i++){
				if(player.HitBox.Intersects(generatedPortions[i].Bounds)){
					curPortion = generatedPortions[i];
					break;
				}
			}
			if(curPortion == null) {
				return;
			}
				
			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X - Portion.PORTION_WIDTH - Portion.TILE_WIDTH,
				curPortion.Bounds.Min.Y - Portion.PORTION_HEIGHT - Portion.TILE_HEIGHT, 0),
				new Vector3(curPortion.Bounds.Max.X - Portion.PORTION_WIDTH - Portion.TILE_WIDTH,
					curPortion.Bounds.Max.Y - Portion.PORTION_HEIGHT - Portion.TILE_HEIGHT, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X,
				curPortion.Bounds.Min.Y - Portion.PORTION_HEIGHT - Portion.TILE_HEIGHT, 0),
				new Vector3(curPortion.Bounds.Max.X,
					curPortion.Bounds.Max.Y - Portion.PORTION_HEIGHT - Portion.TILE_HEIGHT, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X + Portion.PORTION_WIDTH + Portion.TILE_WIDTH,
				curPortion.Bounds.Min.Y - Portion.PORTION_HEIGHT - Portion.TILE_HEIGHT, 0),
				new Vector3(curPortion.Bounds.Max.X + Portion.PORTION_WIDTH + Portion.TILE_WIDTH,
					curPortion.Bounds.Max.Y - Portion.PORTION_HEIGHT - Portion.TILE_HEIGHT, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X + Portion.PORTION_WIDTH + Portion.TILE_WIDTH,
				curPortion.Bounds.Min.Y, 0),
				new Vector3(curPortion.Bounds.Max.X + Portion.PORTION_WIDTH + Portion.TILE_WIDTH,
					curPortion.Bounds.Max.Y, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X + Portion.PORTION_WIDTH + Portion.TILE_WIDTH,
				curPortion.Bounds.Min.Y + Portion.PORTION_HEIGHT + Portion.TILE_HEIGHT, 0),
				new Vector3(curPortion.Bounds.Max.X + Portion.PORTION_WIDTH + Portion.TILE_WIDTH,
					curPortion.Bounds.Max.Y + Portion.PORTION_HEIGHT + Portion.TILE_HEIGHT, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X,
				curPortion.Bounds.Min.Y + Portion.PORTION_HEIGHT + Portion.TILE_HEIGHT, 0),
				new Vector3(curPortion.Bounds.Max.X,
					curPortion.Bounds.Max.Y + Portion.PORTION_HEIGHT + Portion.TILE_HEIGHT, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X - Portion.PORTION_WIDTH - Portion.TILE_WIDTH,
				curPortion.Bounds.Min.Y + Portion.PORTION_HEIGHT + Portion.TILE_HEIGHT, 0),
				new Vector3(curPortion.Bounds.Max.X - Portion.PORTION_WIDTH - Portion.TILE_WIDTH,
					curPortion.Bounds.Max.Y + Portion.PORTION_HEIGHT + Portion.TILE_HEIGHT, 0));
			CheckNewPortion(bounds);

			bounds = new BoundingBox(new Vector3(curPortion.Bounds.Min.X - Portion.PORTION_WIDTH - Portion.TILE_WIDTH,
				curPortion.Bounds.Min.Y, 0),
				new Vector3(curPortion.Bounds.Max.X - Portion.PORTION_WIDTH - Portion.TILE_WIDTH,
					curPortion.Bounds.Max.Y, 0));
			CheckNewPortion(bounds);
		}

		//Generates a new portion if none exists inte the given bounds.
		public void CheckNewPortion(BoundingBox bounds){
			if(!IsGenerated(bounds)) {
				Portion newPortion = new Portion(bounds);
				newPortion.AddPortion(generatedPortions, engine.Entities);
			}
		}

		/* Evaluates to true if the BoundingBox intersects any of the generated portions. */
		public bool IsGenerated(BoundingBox bounds){
			for(int i = 0; i < generatedPortions.Count; i++) {
				if(generatedPortions[i].Bounds.Intersects(bounds)) {
					return true;
				}
			}
			return false;
		}
	}
}