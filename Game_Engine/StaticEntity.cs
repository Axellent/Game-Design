using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class StaticEntity : RenderedEntity{
	
		public StaticEntity(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture) : base(id, x, y, width, height, rotation, hitbox, layer, texture){
		}
	}
}