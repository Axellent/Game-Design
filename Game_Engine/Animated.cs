using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class AnimatedEntity : Entity{
		Texture2D texture;
		int layer;

		public Texture2D Texture{
			get{
				return texture;
			}
			set{
				texture = value;
			}
		}

		public int Layer{
			get{
				return layer;
			}
			set{
				layer = value;
			}
		}

		public AnimatedEntity(float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture) : base(x, y, width, height, rotation, hitbox){
			this.layer = layer;
			this.texture = texture;
		}
	}
}

