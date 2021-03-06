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
		private bool isUsing;
		private int health;
		private int maxHealth;
		private int maxHunger;
		private int hunger;
		private bool isController;
		private float footTicker;
		private float movementSpeed;

		public int MaxHunger {
			get {
				return maxHunger;
			}
			set {
				maxHunger = value;
			}
		}

		public int MaxHealth {
			get {
				return maxHealth;
			}
			set {
				maxHealth = value;
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

		public int Health {
			get {
				return health;
			}
			set {
				health = value;
			}
		}

		public int Hunger {
			get {
				return hunger;
			}
			set {
				hunger = value;
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

		public bool IsUsing {
			get {
				return isUsing;
			}
			set {
				isUsing = value;
			}
		}

		//Player constructor. Inherits ActorEntity
		public Player (string playerName, bool isController, float X, float Y, float width, float height,
				float rotation, BoundingBox hitbox, int layer, Texture2D texture, bool playerControlled) 
				: base(playerName, X, Y, width, height,  rotation, hitbox, layer, texture, playerControlled){
			movementSpeed = 2.0F;
			isMoving = false;
			health = 100;
			hunger = 100;
			maxHealth = 100;
			maxHunger = 100;
			this.isController = isController;
		}
	}
}
