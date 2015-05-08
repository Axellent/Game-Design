using System;
using Survival_Game;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: in iteration 3
	public class StartMenu
	{
		public StartMenu (){
			
		}

		public void LoadContent(){

		}

		public void Update(){

		}

		public void Draw(){

		}
		//TODO: add functionality for button click... might be moved to MenuController
		public MenuController.Menu OnClick(string element){

			if (element.Equals ("Omenu"))
				return MenuController.Menu.OptionMenu;
			else if (element.Equals ("PMenu"))
				return MenuController.Menu.PlayGameMenu;

			return MenuController.Menu.None;
		}
	}
}

