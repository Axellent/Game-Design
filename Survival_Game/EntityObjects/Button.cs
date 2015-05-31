using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game
{
	public class Button : MenuComponent{
		private bool playerSelectedCalled = false;

		public bool PlayerSelectedCalled {
			get {
				return playerSelectedCalled;
			}
			set {
				playerSelectedCalled = value;
			}
		}

		public entitySelected playerSelected;

		public void OnPlayerSelect(string playerName, bool isController){
			if (playerSelected != null) {
				playerSelected (new PlayerNameEventArgs (playerName, isController));
				PlayerSelectedCalled = true;
			}
		}

		public Button (string id, float x, float y, float width, float height, float rotation, 
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, bool isHighlighted, int order)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision, isHighlighted, order){
		}
	}
}
	