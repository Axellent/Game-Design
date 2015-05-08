using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

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
				
		public List<KeyValuePair<Entity, Entity>> UpdatePhysics(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs;

			collisionPairs = CollisionDetection(entities);
			return collisionPairs;
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
					if (!entities [i].Equals (entities [j])) {
						if (entities [i].HitBox.Intersects (entities [j].HitBox)) {
							if (entities [i].Equals (entities [j])) {
								Console.WriteLine ("??");
							} else {
								collisionPairs.Add (new KeyValuePair<Entity, Entity> (entities [i], entities [j]));
								Console.WriteLine ("denna funkar nu?" + entities [i].ID + entities [j].ID);
							}
						}
					}
				}
			}
			return collisionPairs;
		}
	}
}

