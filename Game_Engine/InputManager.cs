using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game_Engine{

	public class InputManager{
		public const float PLAYER_MOVE_SPEED = 2;

		private float playerRotation = 0;
		private float worldX;
		private float worldY;

		public float PlayerRotation{
			get{
				return playerRotation;
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

		public InputManager(){
			worldX = 0;
			worldY = 0;
		}

		public void HandleInput(){
			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Left)){
				playerRotation = (float)Math.PI / 2;
				worldX += PLAYER_MOVE_SPEED;
			}
			if (keyboardState.IsKeyDown(Keys.Right)){
				playerRotation = (float)Math.PI * (float)1.5;
				worldX -= PLAYER_MOVE_SPEED;
			}
			if (keyboardState.IsKeyDown(Keys.Up)){
				playerRotation = (float)Math.PI;
				worldY += PLAYER_MOVE_SPEED;
			}
			if (keyboardState.IsKeyDown(Keys.Down)){
				playerRotation = 0;
				worldY -= PLAYER_MOVE_SPEED;
			}
		}
	}
}

