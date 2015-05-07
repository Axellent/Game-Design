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

		public IDisposable SubscribeObserver(IObserver<Entity> observer){
			return physicsManager.Subscribe (observer);
		}

		protected override void LoadContent(){
			List<string> contentNames = new List<string>();
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: move to survival game
			contentNames.Add("player_s");

			gameContent = renderManager.LoadContent(Content, contentNames);
			entities.Add(new ActorEntity("player1", 0, 0, 50, 50, 0, new BoundingBox(), 1, gameContent[0], false));
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){
			List<string> actions;

			//TODO:resolve these actions
			actions = inputManager.HandleInput();
			physicsManager.UpdatePhysics(entities);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			List<AnimatedEntity> animated = sceneManager.SortAnimatedEntities(entities);
			renderManager.Draw(spriteBatch, GraphicsDevice, animated);
			base.Draw(gameTime);
		}
	}
}

