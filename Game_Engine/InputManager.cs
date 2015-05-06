using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game_Engine{

	public class InputManager{

		public InputManager(){
		}

		public string HandleInput(){
			KeyboardState keyboardState = Keyboard.GetState();
			Keys[] keys = keyboardState.GetPressedKeys();

			if (keys.Length > 0) {
				string keyValue = keys[0].ToString();
				/* Check if keyValue is equal to any of the keyBind inputs and return
				 * the action if so. */
			}
			return "none";
		}
	}
}

