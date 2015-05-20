using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class EntityObserver : IObserver<List<KeyBind>>
	{
		GameEngine engine;
		private float playerSpeed;
		private IDisposable removeableObserver;
		private List<Player> oldPlayers;

		public EntityObserver (GameEngine engine)
		{
			oldPlayers = new List<Player> ();
			this.engine = engine;
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
		public void OnNext (List<KeyBind> value)
		{
			engine.Entities.ForEach (delegate(Entity entity) {
				if (entity.GetType() == typeof(Player)){
					Player player = (Player) entity;				//From here, move to a method.
					if (!IsCollision (player)) {
						AddPlayerToList (player);
						List<KeyBind> playerKeyBinds = value.FindAll (x => x.EntityID.Equals (player.ID));
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
									player.Rotation = (float)Math.PI - player.Rotation / 2;
								else
									player.Rotation = (float)Math.PI;
								player.Y -= playerSpeed;
								break;
							case "down":
								if (actionMade > 1)
									player.Rotation = 0 + player.Rotation / 2;
								else
									player.Rotation = 0;
								player.Y += playerSpeed;
								break;
							case "left":
								if (actionMade > 1)
									player.Rotation = player.Rotation / 2 + (float)Math.PI / 4;
								else
									player.Rotation = (float)Math.PI / 2;
								player.X -= playerSpeed;
								break;
							case "right":
								if (actionMade > 1)
									player.Rotation = -(float)Math.PI / 4 - player.Rotation / 2;
								else
									player.Rotation = -(float)Math.PI / 2;
								player.X += playerSpeed;
								break;
							case "action":
								break;
							default: 
								break;
							}
							actionMade++;
						}
					} else {
						if (oldPlayers.Exists (p => p.ID.Equals (player.ID))) {
							Player temp = oldPlayers.Find (p => p.ID.Equals (player.ID));
							player.X = temp.X;
							player.Y = temp.Y;
							player.HitBox = temp.HitBox;
							player.IsMoving = false;
						}
					}
				}			
			});
		}



		public void AddPlayerToList(Player player){
			oldPlayers.RemoveAll (p => p.ID.Equals(player.ID));
			oldPlayers.Add (new Player(player.ID, player.IsController, player.X, 
				player.Y, player.Width, player.Height, player.Rotation, player.HitBox, 
				player.Layer, player.Texture, player.PlayerControlled));
		}

		//inputs a player that should be checked for collision with an other player
		public bool	IsCollision(Player player){
			foreach(KeyValuePair<Entity, Entity> collision in engine.CollisionPairs){
				if ((player.ID).Equals (collision.Key.ID) || (player.ID).Equals (collision.Value.ID))
					return true;
			}
			return false;
		}

		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}

		public void OnCompleted ()
		{
			foreach (Player player in engine.Entities)
				player.IsMoving = false;
		}
	}
}