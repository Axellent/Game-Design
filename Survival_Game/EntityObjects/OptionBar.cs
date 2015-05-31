using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class OptionBar : MenuComponent
	{
		
		private int tenPercentage;

		public int TenPercentage {
			get {
				return tenPercentage;
			}
			set {
				tenPercentage = value;
			}
		}

		public OptionBar (string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, bool isHighlighted, int tenPercentage, int order, Rectangle rect)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision, isHighlighted, order, rect)
		{
			this.tenPercentage = tenPercentage;
		}
	}
}

