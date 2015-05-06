using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class StaticEntity : AnimatedEntity{
	
		public StaticEntity(float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			Texture2D texture) : base(x, y, width, height, rotation, hitbox, texture){
		}
	}
}

