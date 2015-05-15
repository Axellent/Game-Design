using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl
	* Mediator for the game engine. */
	public class GameEngine : Game, IObservable<List<KeyBind>>, IObservable<List<Texture2D>>, IObservable<List<KeyValuePair<Entity, Entity>>>{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;
		List<Entity> entities;
		List<Texture2D> gameContent;
		IObserver<List<KeyBind>> entityObserver;
		IObserver<List<Texture2D>> contentObserver;
		IObserver<List<KeyValuePair<Entity,Entity>>> collisionObserver;
		List<string> contentNames;
		List<KeyBind> keyBinds = new List<KeyBind>();
		List<KeyBind> actions = new List<KeyBind>();
		List<KeyValuePair<Entity, Entity>> collisionPairs;

		public List<string> ContentNames{
			get{
				return contentNames;
			}
			set{
				contentNames = value;
			}
		}

		/* The entities currently active in the engine,
		 * this list does not include entities outside render distance. */
		public List<Entity> Entities{
			get{
				return entities;
			}
			set{
				entities = value;
			}
		}

		/* All textures currently loaded. */
		public List<Texture2D> GameContent{
			get{
				return gameContent;
			}
			set{
				gameContent = value;
			}
		}

		/* Holds all keybinds the game uses. */
		public List<KeyBind> KeyBind{
			get{ 
				return keyBinds;
			}
			set{ 
				keyBinds = value;
			}
		}

		/* Initialises graphics, content, managers, and entities.*/
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


		public Texture2D changeTexture(string textureName){
			return gameContent.Find (t => t.Name.Equals (textureName));
		}

		public Entity getEntity(string entityID){
			return entities.Find (e => e.ID.Equals (entityID));
		}

		public IDisposable Subscribe(IObserver<List<KeyValuePair<Entity, Entity>>> observer){
			this.collisionObserver = observer;
			return new Unsubscriber<IObserver<List<KeyValuePair<Entity, Entity>>>> (observer);
		}
			
		/* Loads all content in contentNames. 
		 * Overrides the default MonoGame LoadContent method.*/
		protected override void LoadContent(){
			spriteBatch = new SpriteBatch(GraphicsDevice);

			gameContent = renderManager.LoadContent(Content, contentNames);
			contentObserver.OnNext(GameContent);

			base.LoadContent();
		}
				
		protected override void Draw(GameTime gameTime){
			List<RenderedEntity> rendered = sceneManager.SortRenderedEntities(entities);
			renderManager.Draw(spriteBatch, GraphicsDevice, rendered);
			base.Draw(gameTime);
		}


		public IDisposable Subscribe (IObserver<KeyBind> observer){
			this.entityObserver = observer;
			return new Unsubscriber<IObserver<List<KeyBind>>>(observer);
		}

		public IDisposable Subscribe (IObserver<List<Texture2D>> observer){

			this.contentObserver = observer;
			return new Unsubscriber<IObserver<List<Texture2D>>>(observer);
		}


		private class Unsubscriber <T> : IDisposable
		{
			private T observer;

			public Unsubscriber(T observer){
				this.observer = observer;
			}

			public void Dispose(){
				observer = default(T);
			}
		}

		/* Loads all content in contentNames */
		protected override void LoadContent(){
			spriteBatch = new SpriteBatch(GraphicsDevice);
			collisionPairs = new List<KeyValuePair<Entity, Entity>> ();
			gameContent = renderManager.LoadContent(Content, contentNames);
			contentObserver.OnNext(GameContent);

			base.LoadContent();
		}

		/* Handles updates to input and physics.
		 * Overrides the default MonoGame Update method. */
		protected override void Update(GameTime gameTime){
			actions = inputManager.HandleInput(keyBinds);
			entities = physicsManager.UpdateHitboxes(entities);
			entityObserver.OnNext (actions);
			collisionPairs = physicsManager.UpdatePhysics(entities);
			collisionObserver.OnNext (collisionPairs);
			contentObserver.OnNext(GameContent);
			entityObserver.OnCompleted();
			base.Update(gameTime);
		}

		/* Draws all animated entities, sorted by layer.
		 * Overrides the default MonoGame Draw method. */
		protected override void Draw(GameTime gameTime){
			List<AnimatedEntity> animated = sceneManager.SortAnimatedEntities(entities);
			renderManager.Draw(spriteBatch, GraphicsDevice, animated);
			base.Draw(gameTime);
		}
	}
}
