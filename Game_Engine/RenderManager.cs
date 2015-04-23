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
		}

		public void Draw(SpriteBatch batch, GraphicsDevice device, List<SceneObject> sceneObjects){
			batch.Begin();
			device.Clear(Color.DarkOliveGreen);

			for(int i = 0; i < sceneObjects.Count; i++){
				batch.Draw(sceneObjects[i].Texture, new Vector2(sceneObjects[0].X, sceneObjects[i].Y));
			}

			//batch.Draw(player_s, new Vector2(device.Viewport.Width / 2 - player_s.Width / 2, device.Viewport.Height / 2 - player_s.Width / 2));
			batch.End();
		}
	}
}

