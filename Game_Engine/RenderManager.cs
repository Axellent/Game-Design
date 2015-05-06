using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game_Engine{

	public class RenderManager{
		private GraphicsDeviceManager graphics;

		public RenderManager(GraphicsDeviceManager graphics){
			this.graphics = graphics;
		}

		public List<Texture2D> LoadContent(ContentManager Content, List<string> contentFiles){
			List<Texture2D> content = new List<Texture2D>();

			foreach (string contentFile in contentFiles){
				content.Add(Content.Load<Texture2D>(contentFile));
			}
			return content;
		}

		public void Draw(SpriteBatch batch, GraphicsDevice device, List<Entity> entities){
			Color tintColor = Color.White;

			batch.Begin();
			device.Clear(Color.DarkOliveGreen);

			foreach(Entity entity in entities){
				// TODO: batch.Draw entity if it is of the AnimatedEntity type
			}

			//batch.Draw(player_s, new Vector2(device.Viewport.Width / 2 - player_s.Width / 2, device.Viewport.Height / 2 - player_s.Width / 2));
			batch.End();
		}
	}
}

