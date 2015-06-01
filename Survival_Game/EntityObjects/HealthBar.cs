using System;
using Game_Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Survival_Game
{	//I am thinking that this class can be used to show the health of an object
	//
	public class HealthBar: RenderedEntity
	{	

		private Entity conectedTo; 

		public Entity ConectedTo {
			get {
				return conectedTo;
			}
		}

 

		public void updatePosition(int width){
			this.X = conectedTo.X;
			this.Y = conectedTo.Y - 50;
			this.Width = width;
		}

		public HealthBar(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, Entity entity) : base(id, x, y, width, height, rotation, hitbox, layer, texture){
			conectedTo = entity;
		}

		public HealthBar(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool hasCollision, Entity entity)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			conectedTo = entity;
		}
	}
}

