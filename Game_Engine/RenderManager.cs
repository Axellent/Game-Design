using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	public class RenderManager{
		private GraphicsDeviceManager graphics;
		private Texture2D player_s;
		private Texture2D player_l;
		private Texture2D player_r;
		public Texture2D tmp;

		public Texture2D Player_s{
			get{
				return player_s;
			}
		}

		public RenderManager(GraphicsDeviceManager graphics){
			this.graphics = graphics;
		}

		public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content){
			player_s = Content.Load<Texture2D>("player_s");
			player_l = Content.Load<Texture2D>("player_l");
			player_r = Content.Load<Texture2D>("player_r");
			tmp = Content.Load<Texture2D>("tmp");
		}

		public void Draw(SpriteBatch batch, GraphicsDevice device, List<SceneObject> sceneObjects){
			Color tintColor = Color.White;

			batch.Begin();
			device.Clear(Color.DarkOliveGreen);

			for(int i = 0; i < sceneObjects.Count; i++){
				if (!sceneObjects [i].Texture.Name.Equals ("player_s")) {
					batch.Draw (sceneObjects [i].Texture, new Vector2 (sceneObjects [i].X, sceneObjects [i].Y));
				}
				else{
					Rectangle playerRectangle = new Rectangle(0, 0, Convert.ToInt32(sceneObjects[i].Width), Convert.ToInt32(sceneObjects[i].Height));
					Vector2 playerOrigin = new Vector2(sceneObjects[i].Width / 2, sceneObjects[i].Height / 2);
					batch.Draw (sceneObjects[i].Texture, new Vector2(sceneObjects[i].X, sceneObjects[i].Y),
						playerRectangle, tintColor, sceneObjects[i].Rotation, playerOrigin, 1.0f, SpriteEffects.None, 1);
				}
			}

			//batch.Draw(player_s, new Vector2(device.Viewport.Width / 2 - player_s.Width / 2, device.Viewport.Height / 2 - player_s.Width / 2));
			batch.End();
		}
	}
}

