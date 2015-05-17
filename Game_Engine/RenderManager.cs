using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game_Engine{

	//author: Martin Jakobsson
	public class RenderManager{
		private GraphicsDeviceManager graphics;

		public void Initialise(){
			graphics.CreateDevice();
			//graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
			//graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
			//graphics.IsFullScreen = true;
			graphics.ApplyChanges();


			//base.Initialize();


			new Viewport();

		}

		public void stopFullScreen(){
			graphics.IsFullScreen = false;
			graphics.ApplyChanges();
		}
			
		public RenderManager(GraphicsDeviceManager graphics){
			this.graphics = graphics;
			Initialise ();
		}

		/* Loads all desired textures from their content files. */
		public List<Texture2D> LoadContent(ContentManager Content, List<string> contentFiles){
			List<Texture2D> content = new List<Texture2D>();

			foreach (string contentFile in contentFiles){
				content.Add(Content.Load<Texture2D>(contentFile));
			}
			return content;
		}

		/* Draws all renderable entities with respect to their textures, positions, and rotations. */
		public void Draw(SpriteBatch batch, GraphicsDevice device, Vector3 viewPos, List<RenderedEntity> entities){
			Rectangle rect;
			Vector2 origin;
			Color tintColor = Color.White;

			batch.Begin(SpriteSortMode.Texture, null, null, null, null, null,
				Matrix.CreateTranslation(viewPos));
			device.Clear(Color.DarkOliveGreen);

			foreach(RenderedEntity entity in entities){
				rect = new Rectangle(0, 0, Convert.ToInt32(entity.Width), Convert.ToInt32(entity.Height));
				origin = new Vector2(entity.Width / 2, entity.Height / 2);
				batch.Draw(entity.Texture, new Vector2(entity.X, entity.Y), rect, tintColor, entity.Rotation,
					origin, 1.0f, SpriteEffects.None, 1);
			}

			batch.End();
		}
	}
}
