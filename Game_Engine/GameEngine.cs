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

		public IDisposable SubscribeObserver(IObserver<Entity> observer){){
			return physicsManager.Subscribe (observer);
		}

		protected override void LoadContent(){

			spriteBatch = new SpriteBatch(GraphicsDevice);
			//Change second parameter to list of content names
			gameContent = renderManager.LoadContent(Content, new List<string>());


			/*player = renderManager.Player_s;
			sceneManager.AddSceneObject(new SceneObject(renderManager.tmp, GraphicsDevice.Viewport.Width / 2 - renderManager.tmp.Width / 2, 100, renderManager.tmp.Width, renderManager.tmp.Height, 0));
			sceneManager.AddSceneObject(new SceneObject(player, GraphicsDevice.Viewport.Width / 2 - player.Width / 2, GraphicsDevice.Viewport.Height / 2 - player.Height / 2,
				player.Width, player.Height, 0));*/
			//sceneManager.AddSceneObject(new SceneObject(player, GraphicsDevice.Viewport.Width / 3 - player.Width / 2, GraphicsDevice.Viewport.Height / 2 - player.Height / 2,
				//player.Width, player.Height, 0));

			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){

			//inputManager.HandleInput();
			/*physicsManager.UpdatePhysics(new Vector2(inputManager.WorldX, inputManager.WorldY), new Vector2(inputManager.OldWorldX, inputManager.OldWorldY), sceneManager.SceneObjects, inputManager.PlayerRotation);
			sceneManager.SceneObjects = physicsManager.SceneObjects;*/

			String action;

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

