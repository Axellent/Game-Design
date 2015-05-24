using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: Choose how many players want to play, a back-button and playbutton.
	public class PlayGameMenu
	{
		List<Player> players;
		private GameEngine engine;

		public PlayGameMenu(GameEngine engine){
			this.engine = engine;
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

