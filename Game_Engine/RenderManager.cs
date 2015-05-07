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

		public void Draw(SpriteBatch batch, GraphicsDevice device, List<AnimatedEntity> entities){
			Color tintColor = Color.White;

			batch.Begin();
			device.Clear(Color.DarkOliveGreen);

			foreach(AnimatedEntity entity in entities){
				batch.Draw(entity.Texture, new Vector2(entity.X, entity.Y));
			}

			batch.End();
		}
	}
}

