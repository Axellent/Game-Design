using System;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class Entity{
		string id;
		float x, y, width, height, rotation;
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

		public BoundingBox HitBox{
			get{
				return hitbox;
			}
			set{
				hitbox = value;
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
		}
	}
}

