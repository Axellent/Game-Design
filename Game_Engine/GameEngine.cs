using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class GameEngine : Game, IObservable<KeyBind>{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;
		List<Entity> entities;
		List<Texture2D> gameContent;
		IObserver<KeyBind> observer;
		List<string> contentNames;
		List<KeyBind> keyBinds = new List<KeyBind>();
		List<KeyBind> actions = new List<KeyBind>();

		public List<string> ContentNames {
			get {
				return contentNames;
			}
			set {
				contentNames = value;
			}
		}

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

		public List<KeyBind> KeyBind{
			get{ 
				return keyBinds;
			}
			set{ 
				keyBinds = value;
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

		public IDisposable Subscribe (IObserver<KeyBind> observer)
		{
			this.observer = observer;
			return new Unsubscriber (observer);
		}

		private class Unsubscriber : IDisposable {

			private IObserver<KeyBind> _observer;

			public Unsubscriber(IObserver<KeyBind> observer){
				_observer = observer;
			}

			public void Dispose ()
			{
				_observer = null;
			}
		}

		protected override void LoadContent(){
			//List<string> contentNames = new List<string>();
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: move to survival game
			//contentNames.Add("player_s");

			gameContent = renderManager.LoadContent(Content, contentNames);
			entities.Add(new ActorEntity("player1", 100, 100, 72, 50, 0, new BoundingBox(), 1, gameContent[0], false));
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){
			//TODO:resolve these actions
			actions = inputManager.HandleInput(keyBinds);
			physicsManager.UpdatePhysics(entities);
			foreach(KeyBind action in actions){
				observer.OnNext (action);
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			List<AnimatedEntity> animated = sceneManager.SortAnimatedEntities(entities);
			renderManager.Draw(spriteBatch, GraphicsDevice, animated);
			base.Draw(gameTime);
		}
	}
}

