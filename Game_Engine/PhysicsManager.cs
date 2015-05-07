﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class PhysicsManager{
<<<<<<< HEAD
		private IObserver<Entity> observer;
=======
		
>>>>>>> dc204429821227e9319e66dc4f8d7aa10e2fb272
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
				
		public void UpdatePhysics(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs;

			collisionPairs = CollisionDetection(entities);
		}
			
		public List<KeyValuePair<Entity, Entity>> CollisionDetection(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs = new List<KeyValuePair<Entity, Entity>>();
			int i, j;

			/*foreach (Entity e1 in entities) {
				foreach (Entity e2 in entities) {
					if (e1.HitBox.Intersects (e2.HitBox))
						collisionPairs.Add(new KeyValuePair<Entity, Entity> (e1, e2));
				}
			}*/

			for (i = 0; i < entities.Count - 1; i++) {
				for (j = 1; j < entities.Count; j++) {
					if (entities[i].HitBox.Intersects (entities[j].HitBox))
						collisionPairs.Add(new KeyValuePair<Entity, Entity> (entities[i], entities[j]));
				}
			}

			return collisionPairs;
		}
	}
}

