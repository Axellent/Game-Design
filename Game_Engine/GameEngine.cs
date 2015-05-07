using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{

	/* Author: Axel Sigl */
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

		public List<KeyValuePair<Entity, Entity>> CollisionPairs {
			get {
				return collisionPairs;
			}
			set {
				collisionPairs = value;
			}
		}


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
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";

			renderManager = new RenderManager (graphics);
			inputManager = new InputManager ();
			sceneManager = new SceneManger ();
			physicsManager = new PhysicsManager ();
			soundManager = new SoundManager ();

			entities = new List<Entity> ();


		}


		public IDisposable Subscribe (IObserver<KeyBind> observer)
		{
			this.entityObserver = observer;
			return new Unsubscriber (observer);
		}

		public IDisposable Subscribe (IObserver<List<Texture2D>> observer)
		{
			this.contentObserver = observer;
			return new Unsubscriber (observer);
		}

		private class Unsubscriber : IDisposable {

			private IObserver<KeyBind> _observer;
			private IObserver<List<Texture2D>> contentObserver;

			public Unsubscriber(IObserver<KeyBind> observer){
				_observer = observer;
			}

			public Unsubscriber(IObserver<List<Texture2D>> observer){
				contentObserver = observer;	
			}

			public void Dispose ()
			{
				_observer = null;
				contentObserver = null;
			}
		}

		protected override void LoadContent(){
			//List<string> contentNames = new List<string>();
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: move to survival game
			//contentNames.Add("player_s");

			gameContent = renderManager.LoadContent(Content, contentNames);
			contentObserver.OnNext(GameContent);
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime){
			
			foreach(Entity entity in entities){ // denna ska nog ligga överst i funktionen 
				entity.HitBox = new BoundingBox(new Vector3(entity.X - (entity.Width / 2),entity.Y -(entity.Height / 2) ,0), 
					new Vector3(entity.X + (entity.Width / 2), entity.Y + (entity.Height / 2) ,0));			
			}
			//TODO:resolve these actions
			actions = inputManager.HandleInput(keyBinds);
			collisionPairs = physicsManager.UpdatePhysics(entities);
			foreach(KeyBind action in actions){
				entityObserver.OnNext (action);
			}

		
			contentObserver.OnNext (GameContent);
			entityObserver.OnCompleted ();
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			List<AnimatedEntity> animated = sceneManager.SortAnimatedEntities(entities);
			renderManager.Draw(spriteBatch, GraphicsDevice, animated);
			base.Draw(gameTime);
		}
	}
}

