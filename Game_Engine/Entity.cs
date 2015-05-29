using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Game_Engine{

	/* Author: Axel Sigl
	 * Base class for all entities. */
	public class Entity{
		string id;
		float x, y, width, height, rotation;
		bool hasCollision;
		Vector3 velocity;
		BoundingBox hitbox;
			
		public string ID{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public float X{
			get{
				return x;
			}
			set{
				x = value;
			}
		}

		public float Y{
			get{
				return y;
			}
			set{
				y = value;
			}
		}

		public float Width{
			get{
				return width;
			}
			set{
				width = value;
			}
		}

		public float Height{
			get{
				return height;
			}
			set{
				height = value;
			}
		}

		public float Rotation{
			get{
				return rotation;
			}
			set{
				rotation = value;
			}
		}

		/* Velocity vector where the values are the velocities for all it's axes. */
		public Vector3 Velocity{
			get{
				return velocity;
			}
			set{
				velocity = value;
			}
		}

		public bool HasCollision{
			get{
				return hasCollision;
			}
			set{
				hasCollision = value;
			}
		}

		/* 3D rectangle for checking collision of entities. */
		public BoundingBox HitBox{
			get{
				return hitbox;
			}
			set{
				hitbox = value;
			}
		}

		public delegate void damageInflicted(EventArgs args);

		public event damageInflicted inflicted;

		public void damageInflict(Entity entity1, Entity entity2){
			if (inflicted != null) {
				inflicted (new EntityEventArgs (entity1, entity2));
			}
		}

		private class EntityEventArgs : EventArgs{
			private Entity entity1, entity2;

			public Entity Entity1 {
				get {
					return entity1;
				}
			}

			public Entity Entity2 {
				get {
					return entity2;
				}
			}

			public EntityEventArgs(Entity entity1, Entity entity2){
				this.entity1 = entity1;
				this.entity2 = entity2;
			}
		}

		public Entity(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox){
			this.id = id;
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			this.rotation = rotation;
			this.hitbox = hitbox;
			hasCollision = true;
		}

		public Entity(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox,
			bool hasCollision){
			this.id = id;
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			this.rotation = rotation;
			this.hitbox = hitbox;
			this.hasCollision = hasCollision;
		}
	}
}

