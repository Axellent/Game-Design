using System;
using System.Collections.Generic;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game{

	/* Author: Axel Sigl */
	public class Wolf : ActorEntity{
		int updateLimiter = 0;
		
		public Wolf(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool playerControlled) : base(id, x, y, width, height, rotation, hitbox, layer, texture, playerControlled){
		}

		public void UpdateWolf(List<Entity> entities){
			List<Player> players = new List<Player>();

			for(int i = 0; i < entities.Count; i++){
				if(entities[i].GetType() == typeof(Player)){
					players.Add((Player)entities[i]);
				}
			}
			if(players.Count > 0) {
				if(PhysicsManager.CheckEntityCollision(this, entities)) {
					this.MoveTowards(players[0], -3);

				}
				else if(updateLimiter == 0 && !PhysicsManager.CheckEntityCollision(this, entities)) {
					this.MoveTowards(players[0], 1);
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


			/*if(vx < 0 && vy < 0){
				this.Rotation = (float)Math.PI - ((float)Math.PI / 2) / 2;
			}
			else if(vx == 0 && vy < 0){
				this.Rotation = (float)Math.PI;
			}
			else if(vx > 0 && vy < 0){
				this.Rotation = (float)Math.PI + ((float)Math.PI / 2) / 2;
			}
			else if(vx > 0 && vy == 0){
				this.Rotation = -(float)Math.PI / 2;
			}
			else if(vx > 0 && vy > 0){
				this.Rotation = (-(float)Math.PI / 2) / 2;
			}
			else if(vx == 0 && vy > 0){
				this.Rotation = 0;
			}
			else if(vx < 0 && vy > 0){
				this.Rotation = ((float)Math.PI / 2) / 2;
			}
			else if(vx < 0 && vy == 0){
				this.Rotation = ((float)Math.PI / 2);
			}*/
		}
	}
}