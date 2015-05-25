using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class TriggerEntity : RenderedEntity{

		public delegate void click(); 

		public TriggerEntity(string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture){
		}

		public TriggerEntity(string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
		}
	}
}