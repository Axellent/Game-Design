using System;
using Survival_Game;

namespace Survival_Game
{
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

		public MenuController.Menu OnClick(string element){

			if (element.Equals ("Omenu"))
				return MenuController.Menu.OptionMenu;
			else if (element.Equals ("PMenu"))
				return MenuController.Menu.PlayGameMenu;

			return MenuController.Menu.None;
		}
	}
}

