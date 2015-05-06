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

		public Player (int playerID, string playerName)
		{
			ID = playerID;
			name = playerName;
			//Filled these parameters with temp values, replace with player data. - Axel
			actor = new ActorEntity(0, 0, 50, 50, 0, new BoundingBox(), null, true);
		}
	}
}

