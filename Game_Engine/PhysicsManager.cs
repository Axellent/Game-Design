using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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

		public void UpdateEntities(List<Entity> entities){
			List<Entity> temp = entities.FindAll(e => e.GetType() == typeof(ActorEntity) || e.GetType().IsSubclassOf(typeof(ActorEntity)));
			for (int i = 0; i < temp.Count; i++) {
				temp [i].X += temp [i].Velocity.X;
				temp [i].Y += temp [i].Velocity.Y;
			}
		}

		public void UpdateHitboxes(List<Entity> entities){

			foreach(Entity entity in entities){
				UpdateEntityHitbox (entity);
			}
		}

		private void UpdateEntityHitbox(Entity entity){
			entity.HitBox = new BoundingBox(new Vector3(entity.X - (entity.Width / 3),
				entity.Y -(entity.Height / 3), 0), 
				new Vector3(entity.X + (entity.Width / 2),
					entity.Y + (entity.Height / 2), 0));
		}

		public void UpdatePhysics(List<Entity> entities){
			UpdateEntities (entities);
			UpdateHitboxes (entities);
			CollisionDetection(entities);
		}
			
		public void CollisionDetection(List<Entity> entities){
			int i, j;

			for (i = 0; i < entities.Count - 1; i++) {
				if(entities[i].HasCollision) {
					for (j = i + 1; j < entities.Count; j++) {
						if (entities[j].HasCollision && entities[i].HitBox.Intersects (entities[j].HitBox)){
							HandleCollision (entities[i], entities[j]);
						}
					}
				}
			}
		}



		private void HandleCollision(Entity entity1, Entity entity2){
			if (entity1.Velocity.X == 0 && entity1.Velocity.Y == 0) {
				entity2.X -= entity2.Velocity.X;
				entity2.Y -= entity2.Velocity.Y;
			} else if (entity2.Velocity.X == 0 && entity2.Velocity.Y == 0) {
				entity1.X -= entity1.Velocity.X;
				entity1.Y -= entity1.Velocity.Y;
			} else {
				
				int entity1_X = (int)entity1.Velocity.X;
				float entity1_X_rest = (float)entity1.Velocity.X % 1;
				int entity1_Y = (int)entity1.Velocity.Y;
				float entity1_Y_rest = (float)entity1.Velocity.Y % 1;
				int entity2_X = (int)entity2.Velocity.X;
				float entity2_X_rest = (float)entity2.Velocity.X % 1;
				int entity2_Y = (int)entity2.Velocity.Y;
				float entity2_Y_rest = (float)entity2.Velocity.Y % 1;

				int i = 0;
				while (entity1.HitBox.Intersects (entity2.HitBox)) {
					if (i % 2 == 0) {
						if (entity1_X != 0) {
							if (entity1_X > 0) {
								entity1.X -= 1;
								entity1_X--;
							} else {
								entity1.X += 1;
								entity1_X++;
							}
						} else if (entity1_X == 0) {
							entity1.X -= entity1_X_rest;
						}
						if (entity1_Y != 0) {
							if (entity1_Y > 0) {
								entity1.Y -= 1;
								entity1_Y--;
							} else {
								entity1.Y += 1;
								entity1_Y++;
							} 
						} else if (entity1_Y == 0) {
							entity1.Y -= entity1_Y_rest;
						}
						UpdateEntityHitbox (entity1);
					} else {
						if (entity2_X != 0) {
							if (entity2_X > 0) {
								entity2.X -= 1;
								entity2_X--;
							} else {
								entity2.X += 1;
								entity2_X++;
							}
						} else if (entity2_X == 0) {
							entity2.X -= entity2_X_rest;
						} 
						if (entity2_Y != 0) {
							if (entity2_Y > 0) {
								entity2.Y -= 1;
								entity2_Y--;
							} else {
								entity2.Y += 1;
								entity2_Y++;
							}
						} else if (entity2_Y == 0) {
							entity2.Y -= entity2_Y_rest;
						}
						UpdateEntityHitbox (entity2);
					}
					i++;
				}
			}
		}
	}
}


