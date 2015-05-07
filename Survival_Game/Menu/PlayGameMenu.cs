using System;
using System.Collections.Generic;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: in iteration 3
	public class PlayGameMenu
	{
		List<Player> players;

		public void LoadContent(){
			players = new List<Player> ();
		}

		public void Update(){
		}

		//TODO: draw PlayGameMenu
		public void Draw(){

		}

		//TODO: Add functionality for button click... Might be moved to the MenuController
		public void OnClick(string element){
			
			if (element.Equals ("Play")) {
				
			}
			if (element.Equals ("Back")) {
				players.Clear ();
			}
		}
	}
}

