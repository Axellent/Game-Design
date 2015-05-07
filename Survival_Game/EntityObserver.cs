using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	public class EntityObserver : IObserver<KeyBind>
	{
		float playerSpeed = 2.0F;
		private Entity oldEntity;
		GameEngine engine;
		private List<Player> players;
		private IDisposable removableObserver;

		public List<Player> Players {
			get {
				return players;
			}
			set {
				players = value;
			}
		}

		public EntityObserver (GameEngine engine)
		{
			this.players = new List<Player> ();
			this.engine = engine;
		}

		public void AddDisposableOBserver(IDisposable disposableObserver){
			removableObserver = disposableObserver;
		}

		public void Unsubscribe()
		{
			removableObserver.Dispose();
			//players.Clear();
		}

		public void OnNext (KeyBind value)
		{
			Entity entity = engine.Entities.Find (x => x.ID.Equals (value.EntityID));
			Player player = players.Find (x => (x.Name).Equals (value.EntityID));

			if (checkCollision (player)) {
				player.IsMoving = false;
				entity = oldEntity;
			}
			player.IsMoving = true;
			switch (value.Action) {
			case "up":
				entity.Y -= playerSpeed;
				entity.Rotation = (float)Math.PI;
				break;
			case "down":
				entity.Y += playerSpeed;
				entity.Rotation = 0;
				break;
			case "left":
				entity.X -= playerSpeed;
				entity.Rotation = (float)Math.PI/2;
 				break;
			case "right":
				entity.X += playerSpeed;
				entity.Rotation = -(float)Math.PI/2;
				break;
			case "action":
				break;
			}
			oldEntity = entity;
		}

		public bool checkCollision(Player player){
			foreach(KeyValuePair<Entity, Entity> collision in engine.CollisionPairs){
				if ((player.Name + player.ID).Equals (collision.Key.ID) || (player.Name + player.ID).Equals (collision.Value.ID))
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
			foreach (Player player in players) {
				player.IsMoving = false;
			}
		}
	}
}