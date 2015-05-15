using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class EntityObserver : IObserver<List<KeyBind>>
	{
		float playerSpeed = 2.0F;
		GameEngine engine;
		private IDisposable removableObserver;
		private float diagonalSpeed;

		public EntityObserver (GameEngine engine)
		{
			diagonalSpeed =(float) Math.Sqrt (Math.Pow (playerSpeed, 2) / 2);
			this.engine = engine;
		}

		public void AddDisposableObserver(IDisposable disposableObserver){
			removableObserver = disposableObserver;
		}

		public void Unsubscribe()
		{
			removableObserver.Dispose();
			//players.Clear();
		}

		//Called by engine. In this method all the changes to the player is made
		//Hint: Not fully working yet, needs to be more dynamic. The collision management only works at certain key input
		public void OnNext (List<KeyBind> value)
		{
			foreach (Player player in engine.Entities) {
				List<KeyBind> playerKeyBinds = value.FindAll (x => x.EntityID.Equals (player.ID));
				if (playerKeyBinds.Count > 1) {
					playerSpeed = diagonalSpeed;
				} else
					playerSpeed = 2.0F;
				int actionMade = 1;
				foreach (KeyBind keybind in playerKeyBinds) {
					player.IsMoving = true;

					switch (keybind.Action) {
					case "up":
						if (actionMade > 1)
							player.Rotation = (float)Math.PI - player.Rotation/2;
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
							player.Rotation = player.Rotation/2 + (float) Math.PI / 4; 
						else 
							player.Rotation = (float)Math.PI/2;
						player.X -= playerSpeed;
						break;
					case "right":
						if (actionMade > 1)
							player.Rotation = - (float)Math.PI / 4 - player.Rotation/2;
						else
							player.Rotation = -(float)Math.PI/2;
						player.X += playerSpeed;
						break;
					case "action":
						break;
					default: 
						break;
					}
					actionMade++;
				}
			}
		}

		//inputs a player that should be checked for collision with an other player
		/*public bool	isCollision(Player player){
			foreach(KeyValuePair<Entity, Entity> collision in engine.CollisionPairs){
				if ((player.Name).Equals (collision.Key.ID) || (player.Name).Equals (collision.Value.ID))
					return true;
			}
			return false;
		}*/

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