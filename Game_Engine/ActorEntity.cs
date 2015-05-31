using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class ActorEntity : RenderedEntity{
		bool playerControlled;

		public bool PlayerControlled{
			get{
				return playerControlled;
			}
			set{
				playerControlled = value;
			}
		}
			
		public ActorEntity(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool playerControlled)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture){
			this.playerControlled = playerControlled;
		}

		public void MoveTowards(Entity entity, float speed, List<Entity> entities){
			Vector3 entityCenter;
			Vector3 actorCenter;
			float vx = 0, vy = 0;

			entityCenter = new Vector3(entity.HitBox.Max.X - entity.Width / 2, entity.HitBox.Max.Y - entity.Height / 2, 0);
			actorCenter = new Vector3(this.HitBox.Max.X - this.Width / 2, this.HitBox.Max.Y - this.Height / 2, 0);

			if(actorCenter.X < entityCenter.X) {
				vx = speed;
			}
			else if(actorCenter.X > entityCenter.X) {
				vx = -speed;
			}
			if(actorCenter.Y < entityCenter.Y) {
				vy = speed;
			}
			else if(actorCenter.Y > entityCenter.Y) {
				vy = -speed;
			}
			this.Velocity = new Vector3(vx, vy, 0);
		}
	}
}

