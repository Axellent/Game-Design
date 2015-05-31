using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game_Engine{

	/* Author: Axel Sigl
	 * An entity which can be drawn on the screen. */
	public class RenderedEntity : Entity{
		Texture2D texture;
		int layer;
		Rectangle rect;
		bool isSpriteSheet;

		public Texture2D Texture{
			get{
				return texture;
			}
			set{
				texture = value;
			}
		} 

		public Rectangle Rect {
			get {
				return rect;
			}
			set {
				rect = value;
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

		public bool IsSpriteSheet {
			get {
				return isSpriteSheet;
			}
			set {
				isSpriteSheet = value;
			}
		}

		public RenderedEntity(string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox, int layer, Texture2D texture) : base(id, x, y, width, height, rotation, hitbox){
			this.layer = layer;
			this.texture = texture;
			this.isSpriteSheet = false;
		}

		public RenderedEntity(string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, Rectangle rect) 
			: base(id, x, y, width, height, rotation, hitbox, hasCollision){
			this.layer = layer;
			this.texture = texture;
			this.rect = rect;
			this.isSpriteSheet = true;
		}

		public RenderedEntity(string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision)
			: base(id, x, y, width, height, rotation, hitbox, hasCollision){
			this.layer = layer;
			this.texture = texture;
			this.isSpriteSheet = false;
		}
	}
}

