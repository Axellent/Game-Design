using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{

	public class HungerBar: RenderedEntity
	{	

		private Entity conectedTo;
		public Entity ConectedTo {
			get {
				return conectedTo;
			}
			set {
				conectedTo = value;
			}
		}

 

		public void updatePosition(int width){
			this.X = conectedTo.X;
			this.Y = conectedTo.Y - 65;
			this.Width = width;
		}

		public HungerBar(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, Entity entity) : base(id, x, y, width, height, rotation, hitbox, layer, texture){
			conectedTo = entity;
		}

		public HungerBar(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool hasCollision, Entity entity)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			conectedTo = entity;
		}
	}
}
