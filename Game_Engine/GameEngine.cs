using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game_Engine{

	/* Author: Axel Sigl
	* Mediator for the game engine. */
	public class GameEngine : Game, IObservable<List<Texture2D>>, IObservable<List<Entity>>{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;
		List<Entity> entities;
		List<Texture2D> gameContent;
		IObserver<List<Entity>> entityObserver;
		IObserver<List<Texture2D>> contentObserver;
		List<string> contentNames;
		List<KeyBind> keyBinds = new List<KeyBind>();
		List<KeyBind> actions = new List<KeyBind>();
		List<KeyValuePair<Entity, Entity>> collisionPairs;
		Vector3 viewPos = new Vector3(0, 0, 0);
		private List<SoundEffect> soundContent;
		private List<string> soundContentNames;

		List<Tuple<Vector3,Viewport,Entity>> viewposes = new List<Tuple<Vector3, Viewport, Entity>>();

		public List<KeyBind> Actions{
			get {
				return actions;
			}
		}

		public List<Tuple<Vector3,Viewport, Entity>> Viewposes{
			get
			{
				return viewposes;
			}
			set{
				viewposes = value;
			}
		}

		public List<KeyValuePair<Entity, Entity>> CollisionPairs{
			get{ 
				return collisionPairs;
			}
		}

		public List<string> SoundContentNames {
			get {
				return soundContentNames;
			}
			set {
				soundContentNames = value;
			}
		}

		public List<SoundEffect> SoundContent {
			get{
				return soundContent;
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

		/* Determines the position of the screen view. */
		public Vector3 ViewPos{
			get{
				return viewPos;
			}
			set{
				viewPos = value;
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

		public void addTextureOnEntity(string textureName, string entityID){
			RenderedEntity rendered = (RenderedEntity)entities.Find (e => e.ID.Equals (entityID));
			rendered.Texture = gameContent.Find (t => t.Name.Equals (textureName));
		}

		public Rectangle getScreenSize(){
			return GraphicsDevice.PresentationParameters.Bounds;
		}

		public void moveEntity(Vector3 velocity, string entityID){
			entities.Find (e => e.ID.Equals (entityID)).Velocity = velocity;
		}

		public void setEntityRotation(float rotation, string entityID){
			entities.Find (e => e.ID.Equals (entityID)).Rotation = rotation;
		}

		public IDisposable Subscribe (IObserver<List<Entity>> observer){
			this.entityObserver = observer;
			return new Unsubscriber<IObserver<List<Entity>>>(observer);
		}

		public IDisposable Subscribe (IObserver<List<Texture2D>> observer){
			this.contentObserver = observer;
			return new Unsubscriber<IObserver<List<Texture2D>>>(observer);
		}

		private class Unsubscriber <T> : IDisposable{
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
			contentNames.Clear ();

			soundContent = soundManager.LoadContent (Content, soundContentNames);
			soundContentNames.Clear ();

			contentObserver.OnNext(GameContent);
			playBackgroundSound (soundContent.Find(s => s.Name.Equals("Sound\\DaySound_02")), true);
			base.LoadContent();
		}

		public void playBackgroundSound(SoundEffect soundEffect, bool isLooped){
			soundManager.playBackgroundSound (soundEffect, isLooped);
		}

		/* Handles updates to input and physics.
		 * Overrides the default MonoGame Update method. */
		protected override void Update(GameTime gameTime){
			entities = sceneManager.RestoreSavedEntities (entities, new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (800, 600, 0)));
			actions = inputManager.HandleInput(keyBinds);

			entityObserver.OnNext (entities);

			BoundingBox limitBox = new BoundingBox(new Vector3(0, 0, 0),
				new Vector3(GraphicsDevice.Viewport.Width + 100, GraphicsDevice.Viewport.Height + 100, 0));
			entities = sceneManager.RemoveFarawayEntities(entities, limitBox);
			entities = sceneManager.RestoreSavedEntities(entities, limitBox);

			entities = physicsManager.UpdateHitboxes(entities);
			collisionPairs = physicsManager.UpdatePhysics(entities);

			contentObserver.OnNext(GameContent);
			entityObserver.OnCompleted();
			entities = sceneManager.RemoveFarawayEntities (entities, new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (800, 600, 0)));
			base.Update(gameTime);
		}

		/* Loads all content in contentNames. 
		 * Overrides the default MonoGame LoadContent method.*/
		protected override void Draw(GameTime gameTime){
			List<RenderedEntity> rendered = sceneManager.SortRenderedEntities(entities);


				renderManager.Draw (spriteBatch, GraphicsDevice, viewPos, rendered, viewposes);
			
				base.Draw (gameTime);

		}
	}
}
