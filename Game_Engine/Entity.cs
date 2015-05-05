using System;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class Entity{
		float x, y, width, height, rotation;
		BoundingBox hitbox;

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

		public BoundingBox HitBox{
			get{
				return hitbox;
			}
			set{
				hitbox = value;
			}
		}

		public Entity(){
			x = 0;
			y = 0;
			width = 0;
			height = 0;
			rotation = 0;
			hitbox = new BoundingBox();
		}

		public Entity(float x, float y, float width, float height, float rotation, BoundingBox hitbox){
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			this.rotation = rotation;
			this.hitbox = hitbox;
		}
	}
}

