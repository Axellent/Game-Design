using System;
using System.Collections.Generic;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game{

	/* Author: Axel Sigl */
	public class Wolf : ActorEntity{
		bool isMoving;
		int health;
		float footTicker;
		float movementSpeed = 1;
		int updateLimiter = 0;

		public bool IsMoving {
			get {
				return isMoving;
			}
			set {
				isMoving = value;
			}
		}

		public float FootTicker {
			get {
				return footTicker;
			}
			set {
				if (value > 10)
					footTicker = 0;
				else
					footTicker = value;
			}
		}

		public float MovementSpeed {
			get {
				return movementSpeed;
			}
			set {
				movementSpeed = value;
			}
		}
		
		public Wolf(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool playerControlled) : base(id, x, y, width, height, rotation, hitbox, layer, texture, playerControlled){
			isMoving = false;
			health = 100;
		}

		public void UpdateWolf(List<Entity> entities){
			List<Player> players = new List<Player>();

			for(int i = 0; i < entities.Count; i++){
				if(entities[i].GetType() == typeof(Player)){
					players.Add((Player)entities[i]);
				}
			}

			if(players.Count > 0) {
				Player targetPlayer = ChooseTarget(players);
				Entity collidedEntity = PhysicsManager.GetEntityCollision(this, entities);

				if(this.HitBox.Intersects(targetPlayer.HitBox)) {
					this.isMoving = true;
					this.MoveTowards(targetPlayer, -movementSpeed * 3);
				}
				else if(collidedEntity != null) {
				}
				else if(updateLimiter == 0) {
					this.isMoving = true;
					this.MoveTowards(targetPlayer, movementSpeed);
					RotateToVelocityVector(targetPlayer);
					updateLimiter = 10;
				}
				else {
					updateLimiter--;
				}
			}
		}

		public Player ChooseTarget(List<Player> players){
			Player chosen = players[0];
			Vector3 chosenPlayerCenter = new Vector3(players[0].HitBox.Max.X - players[0].Width / 2, players[0].HitBox.Max.Y - players[0].Height / 2, 0);
			Vector3 wolfCenter = new Vector3(this.HitBox.Max.X - this.Width / 2, this.HitBox.Max.Y - this.Height / 2, 0);
			float chosenPlayerDist = Vector3.Distance(chosenPlayerCenter, wolfCenter);

			for(int i = 1; i < players.Count; i++){
				Vector3 playerCenter = new Vector3(players[i].HitBox.Max.X - players[i].Width / 2, players[i].HitBox.Max.Y - players[i].Height / 2, 0);
				float newDist = Vector3.Distance(playerCenter, wolfCenter);

				if(newDist < chosenPlayerDist) {
					chosen = players[i];
					chosenPlayerCenter = playerCenter;
					chosenPlayerDist = newDist;
				}
			}
			return chosen;
		}

		/* Rotates the wolf so that it roughly faces the velocity vector. */
		public void RotateToVelocityVector(Player player){
			float vx = this.Velocity.X;
			float vy = this.Velocity.Y;
			Vector3 playerCenter = new Vector3(player.HitBox.Max.X - player.Width / 2, player.HitBox.Max.Y - player.Height / 2, 0);
			Vector3 wolfCenter = new Vector3(this.HitBox.Max.X - this.Width / 2, this.HitBox.Max.Y - this.Height / 2, 0);
				
			if(Math.Abs(wolfCenter.X - playerCenter.X) < Math.Abs(wolfCenter.Y - playerCenter.Y)) {
				if(vy <= 0) {
					this.Rotation = (float)Math.PI;
				}
				else {
					this.Rotation = 0;
				}
			}
			else {
				if(vx <= 0) {
					this.Rotation = (float)Math.PI / 2;
				}
				else{
					this.Rotation = -(float)Math.PI / 2;
				}
			}
		}
	}
}