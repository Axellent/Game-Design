using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class Player : ActorEntity
	{
		private string name;
		private int iD;
		private bool isMoving;
		private int health;

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

		public int ID {
			get {
				return iD;
			}
			set {
				iD = value;
			}
		}

		public Player (int playerID, string playerName, int X, int Y, int width, int height, int rotation, BoundingBox hitbox, int layer, Texture2D texture, bool playerControlled) 
			: base(playerName + playerID , X, Y, width, height,  rotation, hitbox, layer, texture, playerControlled)
		{
			iD = playerID;
			name = playerName;
			isMoving = false;
			health = 100;
			//Filled these parameters with temp values, replace with player data. - Axel
		}
	}
}