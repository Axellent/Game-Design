using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class OptionBar : TriggerEntity
	{
		private int percentage;

		public int Percentage {
			get {
				return percentage;
			}
			set {
				percentage = value;
			}
		}

		public OptionBar (string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, int percentage)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture)
		{
			this.percentage = percentage;
		}
	}
}

