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

		public List<KeyBind<Keys>> HandleInput(List<KeyBind<Keys>> keyBinds){
			List<KeyBind<Keys>> actions = new List<KeyBind<Keys>>();
			KeyboardState keyboardState = Keyboard.GetState();
			//GamePadState gamepadState = GamePad.GetState ();
			List<GamePadState> gamepadStates = GetGamePadStates();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();
			//Buttons[] pressedButtons = gamepadState.Get;


			if (pressedKeys.Length > 0) {
				
				foreach (Keys k in pressedKeys){
					string keyValue = k.ToString();
					foreach (KeyBind<Keys> kb in keyBinds) {
						foreach (Keys key in kb.Keys) {
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

		private void checkGamePadStates(List<GamePadState> gamepadStates, string key){
			switch(key){
				case "DPadDown":
					break;
				case "DPadUp":
					break;
				case "DPadLeft":
					break;	
				case "DPadRight":
					break;
				case "A":
					break;
				case "B":
					break;
				case "X":
					break;
				case "Y":
					break;
				case "Start":
					break;
				case "Back":
					break;
				case "LeftTrigger":
					break;
				case "RightTrigger":
					break;
				case "LeftShoulder":
					break;
				case "RightShoulder":
					break;
				default:
					break;
			}
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
