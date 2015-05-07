using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	public class Player
	{
		private string name;
		private int ID;
		private ActorEntity actor;

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
			ID = playerID;
			name = playerName;
			//Filled these parameters with temp values, replace with player data. - Axel
			actor = new ActorEntity("" + ID, 0, 0, 50, 50, 0, new BoundingBox(), 1, null, true);
		}
	}
}