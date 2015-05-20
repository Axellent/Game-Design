using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class Player : ActorEntity
	{
		private bool isMoving;
		private int health;
		private bool isController;
		private float footTicker;
		private float movementSpeed;
		private List<KeyBind> keybinds;

		public List<KeyBind> Keybinds {
			get {
				return keybinds;
			}
			set {
				keybinds = value;
			}
		}

		public float MovementSpeed {
			get {
				return movementSpeed;
			}
			set {
				movementSpeed = value;
			}
		}

		public float FootTicker {
			get {
				return footTicker;
			}
			set {
				if (value > 10)
					footTicker = 0;
				else
					footTicker = value;
			}
		}

		public bool IsController {
			get {
				return isController;
			}
			set {
				isController = value;
			}
		}

		public bool IsMoving {
			get {
				return isMoving;
			}
			set {
				isMoving = value;
			}
		}

		//Player constructor. Inherits ActorEntity
		public Player (string playerName, bool isController, float X, float Y, float width, float height, 
			float rotation, BoundingBox hitbox, int layer, Texture2D texture, bool playerControlled, List<KeyBind> keybinds) 
			: base(playerName, X, Y, width, height,  rotation, hitbox, layer, texture, playerControlled)
		{
			this.keybinds = keybinds;
			movementSpeed = 2.0F;
			isMoving = false;
			health = 100;
			this.isController = isController;
		}
	}
}