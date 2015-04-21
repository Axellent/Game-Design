using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	public class RenderManager{
		private GraphicsDeviceManager graphics;

		public RenderManager(GraphicsDeviceManager graphics){
			this.graphics = graphics;
		}

		public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice){
			spriteBatch.Begin();
			graphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.End();
		}
	}
}

