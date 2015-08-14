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

		private void UpdateEntities(List<Entity> entities){
			List<Entity> temp = entities.FindAll(e => e.GetType() == typeof(ActorEntity) || e.GetType().IsSubclassOf(typeof(ActorEntity)));
			for (int i = 0; i < temp.Count; i++) {
				temp[i].X += temp[i].Velocity.X;
				temp[i].Y += temp[i].Velocity.Y;
				UpdateEntityHitbox (temp [i]);
				while (CheckEntityCollision (temp [i], entities)) {
					HandleCollision (temp [i]);
					UpdateEntityHitbox (temp [i]);
				}
			}
		}

		//  public void UpdateHitboxes(List<Entity> entities){
		//
		//   foreach(Entity entity in entities){
		//    UpdateEntityHitbox(entity);
		//   }
		//  }

		private void UpdateEntityHitbox(Entity entity){
			entity.HitBox = new BoundingBox(new Vector3(entity.X - (entity.Width / 3),
				entity.Y -(entity.Height / 3), 0), 
				new Vector3(entity.X + (entity.Width / 2),
					entity.Y + (entity.Height / 2), 0));
		}

		public void UpdatePhysics(List<Entity> entities){
			UpdateEntities(entities);
			//UpdateHitboxes(entities);
		}

		public static bool CheckEntityCollision(Entity entity, List<Entity> entities){
			int j;

			for(j = 0; j < entities.Count; j++) {
				if(entities[j].HasCollision && entity.HitBox.Intersects(entities[j].HitBox) && !entity.Equals(entities[j])){
					return true;
				}
			}
			return false;
		}

		public static Entity GetEntityCollision(Entity entity, List<Entity> entities){
			int j;

			for(j = 0; j < entities.Count; j++) {
				if(entities[j].HasCollision && entity.HitBox.Intersects(entities[j].HitBox) && !entity.Equals(entities[j])){
					return entities[j];
				}
			}
			return null;
		}

		private void HandleCollision(Entity entity){
			entity.Y += DivideByLower(Math.Abs(entity.Velocity.Y), Math.Abs(entity.Velocity.X), entity.Velocity.Y < 0);
			entity.X += DivideByLower(Math.Abs(entity.Velocity.X), Math.Abs(entity.Velocity.Y), entity.Velocity.X < 0);
		}

		private float DivideByLower(float num1, float num2, bool isNegative){
			float changer;
			if (num1 < num2) {
				changer = num1 / num2;
				if (!isNegative)
					changer *= -1;
			} else if (num1 == 0){ 
				changer = 0;
			} else {
				changer = -1;
				if (isNegative) changer = 1;
			}
			return changer;
		}
	}
}

