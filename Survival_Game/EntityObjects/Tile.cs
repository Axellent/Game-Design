using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game{

	/* Author: Axel Sigl */
	public class Tile : StaticEntity{

		public Tile(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture) : base(id, x, y, width, height, rotation, hitbox, layer, texture){
		}

		public Tile(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool hasCollision)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
		}
	}
}

