using System;
using System.Collections.Generic;

namespace Survival_Game
{
	public class PlayGameMenu
	{
		List<Player> players;

		public void LoadContent(){
			players = new List<Player> ();
		}

		public void Update(){

		}

		public void Draw(){

		}

		public void OnClick(string element){
			
			if (element.Equals ("Play")) {
				
			}
			if (element.Equals ("Back")) {
				players.Clear ();
			}
		}
	}
}

