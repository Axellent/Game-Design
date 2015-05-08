using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class ActorEntity : AnimatedEntity{
		bool playerControlled;

		public bool PlayerControlled{
			get{
				return playerControlled;
			}
			set{
				playerControlled = value;
			}
		}
			
		public ActorEntity(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool playerControlled)
				: base(id, x, y, width, height, rotation, hitbox, layer, texture){
			this.playerControlled = playerControlled;
		}
	}
}

