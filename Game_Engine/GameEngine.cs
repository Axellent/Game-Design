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
			Texture2D player;

			spriteBatch = new SpriteBatch(GraphicsDevice);
			renderManager.LoadContent(Content);

			player = renderManager.Player_s;
			sceneManager.AddSceneObject(new SceneObject(player, GraphicsDevice.Viewport.Width / 2 - player.Width / 2, GraphicsDevice.Viewport.Height / 2 - player.Height / 2,
				player.Width, player.Height));
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){
			inputManager.HandleInput();
			physicsManager.UpdatePhysics(new Vector2(inputManager.WorldX, inputManager.WorldY), new Vector2(inputManager.OldWorldX, inputManager.OldWorldY), sceneManager.SceneObjects);
			sceneManager.SceneObjects = physicsManager.SceneObjects;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			renderManager.Draw(spriteBatch, GraphicsDevice, sceneManager.SceneObjects);
			base.Draw(gameTime);
		}
	}
}

