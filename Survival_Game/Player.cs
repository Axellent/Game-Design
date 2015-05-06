using System;
using Game_Engine;
using System.Collections.Generic;

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
			actor = new ActorEntity();
		}
	}
}

