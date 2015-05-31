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
			SMenu.AddOptionsButtonListener (optionsButton);
			SMenu.AddPlayButtonListener (playButton);

			OMenu = optionMenu;
			OMenu.AddBackBtnListener (goBackButton);

			PGMenu = PlayGameMenu;
			PGMenu.AddBackBtnListener (goBackButton);

			engine.SetMouseVisibility (true);
			SMenu.CreateStartMenu ();
		}

		private void goBackButton(EventArgs e){
			engine.ClearEntities ();
			currentState = GameState.StartMenu;
			SMenu.CreateStartMenu ();
		}

		private void playButton(EventArgs e){
			engine.ClearEntities ();
			if (currentState.Equals (GameState.StartMenu)) {
				currentState = GameState.PlayGameMenu;	
				PGMenu.CreateMenu ();
			}
		}

		private void exitButton(EventArgs e){
			engine.Exit ();
		}

		private void optionsButton(EventArgs e){
			engine.ClearEntities ();
			currentState = GameState.OptionMenu;
			OMenu.CreateMenu ();
		}
	}
}

