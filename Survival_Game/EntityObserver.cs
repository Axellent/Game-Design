using System;
using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class EntityObserver : IObserver<KeyBind>
	{
		float playerSpeed = 2.0F;
		private List<Entity> oldEntities;
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
			oldEntities = new List<Entity> ();
			this.players = new List<Player> ();
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
		public void OnNext (KeyBind value)
		{
			//TODO: Remove to be replaced by Entity further down 
			Player player = players.Find (x => x.Name.Equals (value.EntityID));

			if (isCollision (player)) {
				player.IsMoving = false;
				Entity oldEntity = oldEntities.FindLast (x => x.ID.Equals(player.ID));
				if (oldEntity != null)
					engine.Entities [engine.Entities.FindIndex (x => x.ID.Equals (oldEntity.ID))] = oldEntity;
				return;
			}
			//Will replace player instance above
			Player entity = (Player)engine.Entities.Find (x => x.ID.Equals (value.EntityID));
			Player tempPlayer = new Player (entity.ID,entity.IsControll, 
				entity.X, entity.Y, entity.Width, entity.Height, entity.Rotation, 
				entity.HitBox, entity.Layer, entity.Texture, entity.PlayerControlled);
			AddEntities (tempPlayer);

			player.IsMoving = true;

			//Manages the entity's movement and rotation
			//TODO: add rotation for diagonal movement 
			switch (value.Action) {
			case "up":
				entity.Y -= playerSpeed;
				/*if ()
					entity.Rotation = (float)Math.PI - entity.Rotation / 2;  //Not working
				else*/
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
		}

		//TODO: Needs to be changed. Right now it only work with one player moving...
		private void AddEntities(Entity entity){
			if (oldEntities.Count == 2){
				if (oldEntities.Exists (x => x.ID.Equals (entity.ID))) {
					oldEntities.Insert (oldEntities.FindIndex (x => x.ID.Equals (entity.ID)), oldEntities.Find (x => x.ID.Equals (entity.ID)));
					oldEntities.Insert (oldEntities.FindLastIndex (x => x.ID.Equals (entity.ID)), entity);
					return;
				}
			} 
			oldEntities.Add (entity);
		}

		//inputs an player that should be checked for collision with an other player
		public bool	isCollision(Player player){
			foreach(KeyValuePair<Entity, Entity> collision in engine.CollisionPairs){
				if ((player.Name).Equals (collision.Key.ID) || (player.Name).Equals (collision.Value.ID))
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