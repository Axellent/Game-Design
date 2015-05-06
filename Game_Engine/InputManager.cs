using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using System.Windows.Forms;



namespace Game_Engine{

	public class InputManager{
		public const float PLAYER_MOVE_SPEED = 2;


		private float playerRotation = 0;
		private float oldWorldX;
		private float oldWorldY;
		private float worldX;
		private float worldY;
		//private int player = (int)PlayerIndex.One;
		private List<KeyBind> keyBinds = new List<KeyBind>();

		public float PlayerRotation{
			get{
				return playerRotation;
			}
		}

		public float OldWorldX{
			get{
				return oldWorldX;
			}
			set{
				oldWorldX = value;
			}
		}

		public float OldWorldY{
			get{
				return oldWorldY;
			}
			set{
				oldWorldY = value;
			}
		}

		public float WorldX{
			get{
				return worldX;
			}
			set{
				worldX = value;
			}
		}

		public float WorldY{
			get{
				return worldY;
			}
			set{
				worldY = value;
			}
		}

		public List<KeyBind> KeyBind{
			get{ 
				return keyBinds;
			}
			set{ 
				keyBinds = value;
			}
		}

		public InputManager(){
			oldWorldX = 0;
			oldWorldY = 0;
			worldX = 0;
			worldY = 0;
		}

		public String HandleInput(){
			KeyboardState keyboardState = Keyboard.GetState();
			GamePadState gamepadstate = GamePad.GetState (PlayerIndex.One);
			KeyClass kc = new KeyClass (keyboardState.GetPressedKeys());

			foreach (Keys keys in kc) {
				foreach (KeyBind kb in keyBinds) {
					foreach (String key in kb.Keys) {
						if (key.Equals(keys)) {
							return kb.Action;
						}
						
					}
				}
			}

			return "none";
		}

		/*public void HandleInput(){
			KeyboardState keyboardState = Keyboard.GetState();
			GamePadState gamepadstate = GamePad.GetState (PlayerIndex.One);

			oldWorldX = worldX;
			oldWorldY = worldY;


				if (keyboardState.IsKeyDown (Keys.A) || 
					gamepadstate.DPad.Left == ButtonState.Pressed) {
					playerRotation = (float)Math.PI / 2;
					worldX -= PLAYER_MOVE_SPEED;
				}
				if (keyboardState.IsKeyDown (Keys.D) || 
					gamepadstate.DPad.Right == ButtonState.Pressed){
					playerRotation = (float)Math.PI * (float)1.5;
					worldX += PLAYER_MOVE_SPEED;
				}
				if (keyboardState.IsKeyDown (Keys.W) || 
					gamepadstate.DPad.Up == ButtonState.Pressed){
					playerRotation = (float)Math.PI;
					worldY -= PLAYER_MOVE_SPEED;
				}
				if (keyboardState.IsKeyDown (Keys.S) || 
					gamepadstate.DPad.Down == ButtonState.Pressed){
					playerRotation = 0;
					worldY += PLAYER_MOVE_SPEED;
				}
			
				if (keyboardState.IsKeyDown (Keys.Left)) {
					playerRotation = (float)Math.PI / 2;
					worldX -= PLAYER_MOVE_SPEED;
				}
				if (keyboardState.IsKeyDown (Keys.Right)) {
					playerRotation = (float)Math.PI * (float)1.5;
					worldX += PLAYER_MOVE_SPEED;
				}
				if (keyboardState.IsKeyDown (Keys.Up)) {
					playerRotation = (float)Math.PI;
					worldY -= PLAYER_MOVE_SPEED;
				}
				if (keyboardState.IsKeyDown (Keys.Down)) {
					playerRotation = 0;
					worldY += PLAYER_MOVE_SPEED;
				}
		}*/
	}
}

