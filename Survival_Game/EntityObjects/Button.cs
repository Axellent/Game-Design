using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game
{
	public class Button : TriggerEntity{

		private bool buttonHighlighted;

		public bool ButtonHighlighted {
			get {
				return buttonHighlighted;
			}
			set {
				buttonHighlighted = value;
			}
		}

		public delegate void buttonPressed();

		public event buttonPressed pressed;

		public void OnButtonPressed (){
			if (pressed != null)
				pressed ();
		}

		public Button (string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, bool buttonHighlighted)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			this.buttonHighlighted = buttonHighlighted;
		}
	}
}

