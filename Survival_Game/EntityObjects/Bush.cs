using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game{

	/* Author: Axel Sigl */
	public class Bush : StaticEntity{

		private int amountOfHungerReduced;
		private int amountOfHealthRestored;
		private bool isUsed;

		public bool IsUsed {
			get {
				return isUsed;
			}
			set {
				isUsed = value;
			}
		}

		public int AmountOfHealthRestored {
			get {
				return amountOfHealthRestored;
			}
			set {
				amountOfHealthRestored = value;
			}
		}

		public int AmountOfHungerReduced {
			get {
				return amountOfHungerReduced;
			}
			set {
				amountOfHungerReduced = value;
			}
		}

		public Bush(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture) : base(id, x, y, width, height, rotation, hitbox, layer, texture){
			amountOfHungerReduced = 10;
			amountOfHealthRestored = 10;
			isUsed = false;
		}

		public Bush(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, 
			int layer, Texture2D texture, bool hasCollision)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			amountOfHungerReduced = 10;
			amountOfHealthRestored = 10;
			isUsed = false;
		}
	}
}