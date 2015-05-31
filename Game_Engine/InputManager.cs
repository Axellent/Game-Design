using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;



namespace Game_Engine{

	/* Author: Andreas Lönnermark */
	public class InputManager{
		private int numControllers = 0;

		public InputManager(){
		}

		public void SetNumberOfController(int numControllers){
			this.numControllers = numControllers;
		}

		public Tuple<List<KeyBind<Keys>>, List<KeyBind<Buttons>>> HandleInput(List<KeyBind<Keys>> keyBinds, List<KeyBind<Buttons>> buttonBinds){
			List<KeyBind<Keys>> keyActions = new List<KeyBind<Keys>>();
			List<KeyBind<Buttons>> buttonActions = new List<KeyBind<Buttons>> ();
			KeyboardState keyboardState = Keyboard.GetState();
			//GamePadState gamepadState = GamePad.GetState ();
			List<GamePadState> gamepadStates = GetGamePadStates();
			Keys[] pressedKeys = keyboardState.GetPressedKeys();
			//Buttons[] pressedButtons = gamepadState.Get;

			KeyBind<Keys> kb;
			for (int l = 0; l < gamepadStates.Count; l++) {
				if (gamepadStates[l].IsConnected){
					for (int k = 0; k < buttonBinds.Count; k++) {
						if (gamepadStates [l].IsButtonDown (buttonBinds [k].Key)) {
							buttonActions.Add (buttonBinds [k]);
						}
					}
				}
			}
			if (pressedKeys.Length > 0) {
				
				for (int j = 0; j < keyBinds.Count; j++){
					for (int i = 0; i < pressedKeys.Length; i++){
						kb = keyBinds [j]; 
						if (kb.Key.Equals(pressedKeys[i])) {
							keyActions.Add (kb);
							break;
						}

					}
				}
			}
			return new Tuple<List<KeyBind<Keys>>, List<KeyBind<Buttons>>>(keyActions, buttonActions);
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
			for (int i = 0; i < numControllers; i++) {
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
