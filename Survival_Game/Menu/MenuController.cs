using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: in iteration 3
	public class MenuController
	{
		public enum Menu {StartMenu, OptionMenu, PlayGameMenu, None};

		private Menu menu;

		private StartMenu SMenu;
		private OptionMenu OMenu;
		private PlayGameMenu PGMenu;

		public MenuController (StartMenu startMenu, OptionMenu optionMenu, PlayGameMenu PlayGameMenu, ContentManager content)
		{
			//Content.RootDirectory = "Content";
			SMenu = startMenu;
			OMenu = optionMenu;
			PGMenu = PlayGameMenu;
			//SMenu.LoadContent(content);
		}

		private void goBackButton()
		{
			
		}

		private void playButton(){

		}
	}
}

