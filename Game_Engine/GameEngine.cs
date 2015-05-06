using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class GameEngine : Game{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;
		List<Entity> entities;
		List<Texture2D> gameContent;

		public List<Entity> Entities{
			get{
				return entities;
			}
			set{
				entities = value;
			}
		}

		public List<Texture2D> GameContent{
			get{
				return gameContent;
			}
			set{
				gameContent = value;
			}
		}

		public GameEngine(){
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			renderManager = new RenderManager(graphics);
			inputManager = new InputManager();
			sceneManager = new SceneManger();
			physicsManager = new PhysicsManager();
			soundManager = new SoundManager();

			entities = new List<Entity>();
		}

		protected override void LoadContent(){

			spriteBatch = new SpriteBatch(GraphicsDevice);
			//Change second parameter to list of content names
			gameContent = renderManager.LoadContent(Content, new List<string>());

			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){
			string action;

			action = inputManager.HandleInput();
			physicsManager.UpdatePhysics(entities);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			renderManager.Draw(spriteBatch, GraphicsDevice, entities);
			base.Draw(gameTime);
		}
	}
}

