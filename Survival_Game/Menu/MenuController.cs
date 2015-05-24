using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game_Engine;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: in iteration 3
	public class MenuController
	{
		private GameState currentState;
		private GameEngine engine;
		private StartMenu SMenu;
		private OptionMenu OMenu;
		private PlayGameMenu PGMenu;

		public MenuController (StartMenu startMenu, OptionMenu optionMenu, PlayGameMenu PlayGameMenu, ref GameState state, GameEngine engine)
		{
			this.engine = engine;
			this.currentState = state;
			currentState = GameState.StartMenu;
			SMenu = startMenu;
			OMenu = optionMenu;
			PGMenu = PlayGameMenu;
			PGMenu.AddBackBtnListener (goBackButton);
			PGMenu.AddPlayBtnListener (playButton);
		}

		private void goBackButton(){
			engine.clearEntities ();
		}

		private void playButton(){
		}
	}
}

