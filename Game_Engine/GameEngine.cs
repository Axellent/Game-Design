using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl
	* Mediator for the game engine. */
	public class GameEngine : Game, IObservable<KeyBind>, IObservable<List<Texture2D>>{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;
		List<Entity> entities;
		List<Texture2D> gameContent;
		IObserver<KeyBind> entityObserver;
		IObserver<List<Texture2D>> contentObserver;
		List<string> contentNames;
		List<KeyBind> keyBinds = new List<KeyBind>();
		List<KeyBind> actions = new List<KeyBind>();
		List<KeyValuePair<Entity, Entity>> collisionPairs;

		/* Pairs of entity collisions to be resolved. */
		public List<KeyValuePair<Entity, Entity>> CollisionPairs{
			get{
				return collisionPairs;
			}
			set{
				collisionPairs = value;
			}
		}

		/* The names of the content files to be loaded. */
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

		/* Loads all content in contentNames. 
		 * Overrides the default MonoGame LoadContent method.*/
		protected override void LoadContent(){
			spriteBatch = new SpriteBatch(GraphicsDevice);

			gameContent = renderManager.LoadContent(Content, contentNames);
			contentObserver.OnNext(GameContent);

			base.LoadContent();
		}

		/* Handles updates to input and physics.
		 * Overrides the default MonoGame Update method. */
		protected override void Update(GameTime gameTime){
			int i;
			actions = inputManager.HandleInput(keyBinds);
			entities = physicsManager.UpdateHitboxes(entities);
			collisionPairs = physicsManager.UpdatePhysics(entities);

			for(i = 0; i < actions.Count; i++){
				entityObserver.OnNext(actions[i]);
			}
		
			contentObserver.OnNext(GameContent);
			entityObserver.OnCompleted();
			base.Update(gameTime);
		}

		/* Draws all animated entities, sorted by layer.
		 * Overrides the default MonoGame Draw method. */
		protected override void Draw(GameTime gameTime){
			List<RenderedEntity> rendered = sceneManager.SortRenderedEntities(entities);
			renderManager.Draw(spriteBatch, GraphicsDevice, rendered);
			base.Draw(gameTime);
		}


		public IDisposable Subscribe (IObserver<KeyBind> observer){
			this.entityObserver = observer;
			return new Unsubscriber(observer);
		}

		public IDisposable Subscribe (IObserver<List<Texture2D>> observer){
			this.contentObserver = observer;
			return new Unsubscriber(observer);
		}

		class Unsubscriber : IDisposable{

			IObserver<KeyBind> _observer;
			IObserver<List<Texture2D>> contentObserver;

			public Unsubscriber(IObserver<KeyBind> observer){
				_observer = observer;
			}

			public Unsubscriber(IObserver<List<Texture2D>> observer){
				contentObserver = observer;	
			}

			public void Dispose(){
				_observer = null;
				contentObserver = null;
			}
		}
	}
}