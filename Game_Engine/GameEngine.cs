using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	public class GameEngine : Game{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;

		public GameEngine(){
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			renderManager = new RenderManager(graphics);
			inputManager = new InputManager();
			sceneManager = new SceneManger();
			physicsManager = new PhysicsManager();
			soundManager = new SoundManager();
		}

		protected override void LoadContent(){
			spriteBatch = new SpriteBatch(GraphicsDevice);
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){
			renderManager.Draw(spriteBatch, GraphicsDevice);
			base.Draw(gameTime);
		}
	}
}

