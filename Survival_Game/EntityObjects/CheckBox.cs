using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class CheckBox : MenuComponent
	{

		private bool isChecked = false;

		public bool IsChecked {
			get {
				return isChecked;
			}
			set {
				isChecked = value;
			}
		}

		public CheckBox (string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, bool isHighlighted, int order)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision, isHighlighted, order)
		{
		}
	}
}

