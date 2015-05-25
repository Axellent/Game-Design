using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
			engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (0, 0, 0), engine.GraphicsDevice.Viewport, null));
			this.currentState = state;
			currentState = GameState.StartMenu;
			SMenu = startMenu;
			SMenu.AddExitButtonListener (exitButton);
			SMenu.AddPlayButtonListener (playButton);

			OMenu = optionMenu;
			PGMenu = PlayGameMenu;
			PGMenu.AddBackBtnListener (goBackButton);
			PGMenu.AddPlayBtnListener (playButton);

			engine.SetMouseVisibility (true);
			SMenu.createStartMenu ();
		}

		private void goBackButton(){
			engine.ClearEntities ();
			SMenu.createStartMenu ();
		}

		private void playButton(){
			engine.ClearEntities ();
			if (currentState.Equals (GameState.StartMenu)) {	
				PGMenu.createMenu ();
			}
		}

		private void exitButton(){

		}

		private void optionsButton(){

		}
	}
}

