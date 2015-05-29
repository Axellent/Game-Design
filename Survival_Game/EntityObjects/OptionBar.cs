using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class OptionBar : TriggerEntity
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
			BoundingBox hitbox, int layer, Texture2D texture, int tenPercentage)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture)
		{
			this.tenPercentage = tenPercentage;
		}
	}
}

