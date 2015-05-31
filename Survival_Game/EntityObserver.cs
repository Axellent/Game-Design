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
		private bool buttonSet;
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
			for (int i = 0; i < engine.Entities.Count; i++) {
				if (engine.Entities[i].GetType () == typeof(Player)) {
					HandlePlayer (engine.Entities[i]);
				}
			}
			if (engine.Entities.Exists(b => b.GetType() == typeof(Button))){
				TimeSpan time = gameTime.TotalGameTime;
				if (oldtimespan.Ticks == 0 || time.TotalMilliseconds - oldtimespan.TotalMilliseconds > 200) { 
					HandleButton (time);
				}
			}
			buttonSet = false;
		}
			
		private void HandleButton (TimeSpan time){
			if (!buttonSet) {
				KeyBind keybind = engine.Actions.Find (k => k.EntityID.Equals ("none"));
				if (keybind != null) {
					switch (keybind.Action) {
					case "up":
						setButtonHighlight (false);
						buttonSet = true;
						oldtimespan = time;
						break;
					case "down":
						setButtonHighlight (true);
						buttonSet = true;
						oldtimespan = time;
						break;
					case "enter":
						setButtonHighlight (null);
						oldtimespan = time;
						break;
					}
				}
			}
		}

		private void setButtonHighlight(bool? nextEntity){
			List<Entity> entities = engine.Entities.FindAll (e => e.GetType () == typeof(Button));
			for (int i = 0; i<entities.Count; i++){
				Button button = (Button) entities[i];
				Button nextButton;
				if (button.ButtonHighlighted) {
					if (nextEntity == null) {
						button.OnButtonPressed ();
					} else if ((bool)nextEntity) {
						if (i < entities.Count - 1) {
							button.ButtonHighlighted = false;
							nextButton = (Button)entities [i + 1];
							nextButton.ButtonHighlighted = true;
							break;
						} else {
							button.ButtonHighlighted = false;
							nextButton = (Button)entities [0];
							nextButton.ButtonHighlighted = true;
							break;
						}
					} else {
						if (i > 0) {
							button.ButtonHighlighted = false;
							nextButton = (Button)entities [i - 1];
							nextButton.ButtonHighlighted = true;
							break;
						} else {
							button.ButtonHighlighted = false;
							nextButton = (Button)entities [entities.Count - 1];
							nextButton.ButtonHighlighted = true;
							break;
						}
					}
				}
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