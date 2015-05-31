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
		public void Draw(SpriteBatch batch, GraphicsDevice device, List<Tuple<Vector3,Viewport, Entity>> viewPositions,
			List<RenderedEntity> entities){
			Rectangle rect;
			Vector2 origin;
			Vector3 viewPos;
			Color tintColor = Color.White;

			device.Clear(Color.DarkOliveGreen);

			foreach(Tuple<Vector3,Viewport, Entity> pair in viewPositions) {
				device.Viewport = pair.Item2;
				viewPos = pair.Item1;

				batch.Begin(SpriteSortMode.Texture, null, null, null, null, null,
					Matrix.CreateTranslation(-viewPos));
				
				foreach(RenderedEntity entity in entities) {
					rect = new Rectangle(0, 0, Convert.ToInt32(entity.Width), Convert.ToInt32(entity.Height));
					origin = new Vector2(entity.Width / 2, entity.Height / 2);
					batch.Draw(entity.Texture, new Vector2(entity.X, entity.Y), rect, tintColor, entity.Rotation,
						origin, 1.0f, SpriteEffects.None, 1);
				}
				batch.End();
			}
		}
	}
}
