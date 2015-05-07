using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	public class Player
	{
		private string name;
		private int iD;
		private bool isMoving;
		private int health;
		private ActorEntity actor;

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

		public ActorEntity Actor {
			get {
				return actor;
			}
			set {
				actor = value;
			}
		}

		public Player (int playerID, string playerName)
		{
			iD = playerID;
			name = playerName;
			isMoving = false;
			health = 100;
			//Filled these parameters with temp values, replace with player data. - Axel
			actor = new ActorEntity("" + iD, 0, 0, 50, 50, 0, new BoundingBox(), 1, null, true);
		}
	}
}