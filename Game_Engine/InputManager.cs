using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;



namespace Game_Engine{

	public class InputManager{
		//private int player = (int)PlayerIndex.One;

		public InputManager(){
		}


		public List<KeyBind> HandleInput(List<KeyBind> keyBinds){
			List<KeyBind> actions = new List<KeyBind>();
			KeyboardState keyboardState = Keyboard.GetState();
			GamePadState gamepadstate = GamePad.GetState (PlayerIndex.One);
			Keys[] pressedKeys = keyboardState.GetPressedKeys();

			if (pressedKeys.Length > 0) {
				string keyValue = pressedKeys[0].ToString();

				foreach (KeyBind kb in keyBinds) {
					foreach (String key in kb.Keys) {
						if (key.Equals(keyValue)) {
							actions.Add(kb);
							break;
						}
						
					}
				}
			}
			return actions;
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
