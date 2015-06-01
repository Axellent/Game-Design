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
				Entity collidedEntity = PhysicsManager.GetEntityCollision(this, entities);

				if(this.HitBox.Intersects(players[0].HitBox)) {
					this.isMoving = true;
					this.MoveTowards(players[0], -movementSpeed * 3);
				}
				else if(collidedEntity != null) {
					//this.isMoving == true;
					//this.MoveTowards(collidedEntity, -3);
				}
				else if(updateLimiter == 0) {
					this.isMoving = true;
					this.MoveTowards(players[0], movementSpeed);
					RotateToVelocityVector(players[0]);
					updateLimiter = 10;
				}
				else {
					updateLimiter--;
				}
			}
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