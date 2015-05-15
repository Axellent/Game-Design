using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl
	 * An entity which can be drawn on the screen. */
	public class RenderedEntity : Entity{
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

		/* Decides which order the entity is displayed
		 * in relation to the other entities. */
		public int Layer{
			get{
				return layer;
			}
			set{
				layer = value;
			}
		}

		public RenderedEntity(string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox,  int layer, Texture2D texture) : base(id, x, y, width, height, rotation, hitbox){
			this.layer = layer;
			this.texture = texture;
		}
	}
}

