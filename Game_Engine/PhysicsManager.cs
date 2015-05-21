using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	/* Author: Andreas Lönnermark */
	public class PhysicsManager{

		private bool collision = false;

		public PhysicsManager(){

		}

		public bool Collision {
			get {
				return collision;
			}
			set {
				collision = value;
			}
		}

		public List<Entity> UpdateHitboxes(List<Entity> entities){

			foreach(Entity entity in entities){
				entity.HitBox = new BoundingBox(new Vector3(entity.X - (entity.Width / 3),
					entity.Y -(entity.Height / 3), 0), 
					new Vector3(entity.X + (entity.Width / 2),
						entity.Y + (entity.Height / 2), 0));			
			}
			return entities;
		}
				
		public List<KeyValuePair<Entity, Entity>> UpdatePhysics(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs;

			collisionPairs = CollisionDetection(entities);
			return collisionPairs;
		}
			
		public List<KeyValuePair<Entity, Entity>> CollisionDetection(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs = new List<KeyValuePair<Entity, Entity>>();
			int i, j;

			for (i = 0; i < entities.Count - 1; i++) {
				for (j = i + 1; j < entities.Count; j++) {
					if (entities[i].HasCollision && entities[i].HitBox.Intersects (entities[j].HitBox)){
						collisionPairs.Add (new KeyValuePair<Entity, Entity> (entities[i], entities[j]));
					}
				}
			}
			return collisionPairs;
		}
	}
}


