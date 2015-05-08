using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class Player : ActorEntity
	{
		private string name;
		private bool isMoving;
		private int health;
		private bool isController;

		public bool IsControll {
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

		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		//Player constructor. Inherits ActorEntity
		public Player (string playerName, bool isController, float X, float Y, float width, float height, float rotation, BoundingBox hitbox, int layer, Texture2D texture, bool playerControlled) 
			: base(playerName, X, Y, width, height,  rotation, hitbox, layer, texture, playerControlled)
		{
			name = playerName;
			isMoving = false;
			health = 100;
			this.isController = isController;
		}
	}
}