using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;



namespace Game_Engine{

	/* Author: Andreas Lönnermark */
	public class InputManager{
		private int numControllers = 0;

		public InputManager(int numControllers){
			this.numControllers = numControllers;
		}


		public List<KeyBind> HandleInput(List<KeyBind> keyBinds){
			List<KeyBind> actions = new List<KeyBind>();
			KeyboardState keyboardState = Keyboard.GetState();
			List<GamePadState> gamepadStates = GetGamePadStates();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();
			//Buttons[] pressedButtons = gamepadState.GetVirtualButtons();

			if (pressedKeys.Length > 0) {
				foreach (Keys k in pressedKeys){
					string keyValue = k.ToString();
					foreach (KeyBind kb in keyBinds) {
						foreach (String key in kb.Keys) {
							if (key.Equals(keyValue)) {
								actions.Add(kb);
								break;
							}
						}
					}
				}
			}


			return actions;
		}

		private List<GamePadState> GetGamePadStates (){
			List<GamePadState> gamePadStates = new List<GamePadState> ();
			for (int i = 1; i < numControllers + 1; i++) {
				gamePadStates.Add(GamePad.GetState ((PlayerIndex)i));
			}
			return gamePadStates;
		}

		/*public string HandleInput(){
			KeyboardState keyboardState = Keyboard.GetState();
			Keys[] keys = keyboardState.GetPressedKeys();

			if (keys.Length > 0) {
				string keyValue = keys[0].ToString();
				/* Check if keyValue is equal to any of the keyBind inputs and return
				 * the action if so. 
			}
			return "none";
		}*/

	}
}
