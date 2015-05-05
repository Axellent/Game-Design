using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	public class AnimatedEntity : Entity{
		Texture2D texture;

		public Texture2D Texture{
			get{
				return texture;
			}
			set{
				texture = value;
			}
		}

		public AnimatedEntity(){

		}

		public AnimatedEntity(float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			Texture2D texture) : base(x, y, width, height, rotation, hitbox){
			this.texture = texture;
		}
	}
}

