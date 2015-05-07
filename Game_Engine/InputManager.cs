using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;



namespace Game_Engine{

	public class InputManager{
		//private int player = (int)PlayerIndex.One;
		private List<KeyBind> keyBinds = new List<KeyBind>();

		public List<KeyBind> KeyBind{
			get{ 
				return keyBinds;
			}
			set{ 
				keyBinds = value;
			}
		}

		public InputManager(){
		}


		public List<string> HandleInput(){
			List<string> actions = new List<string>();
			KeyboardState keyboardState = Keyboard.GetState();
			GamePadState gamepadstate = GamePad.GetState (PlayerIndex.One);
			Keys[] pressedKeys = keyboardState.GetPressedKeys();

			if (pressedKeys.Length > 0) {
				string keyValue = pressedKeys[0].ToString();

				foreach (KeyBind kb in keyBinds) {
					foreach (String key in kb.Keys) {
						if (key.Equals(keyValue)) {
							actions.Add(kb.Action);
							break;
						}
						
					}
				}
			}
			else{
				actions.Add("none");
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
