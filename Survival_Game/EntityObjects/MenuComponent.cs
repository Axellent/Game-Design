using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class MenuComponent : TriggerEntity
	{
		private bool isHighlighted;
		private int order;

		public bool IsHighlighted {
			get {
				return isHighlighted;
			}
			set {
				isHighlighted = value;
			}
		}

		public int Order {
			get {
				return order;
			}
			set {
				order = value;
			}
		}

		public MenuComponent (string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, bool isHighlighted, int order, Rectangle rect) 
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision, rect)
		{
			this.order = order;
			this.isHighlighted = isHighlighted;
		}

		public MenuComponent (string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, bool isHighlighted, int order) 
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision)
		{
			this.order = order;
			this.isHighlighted = isHighlighted;
		}
	}
}

