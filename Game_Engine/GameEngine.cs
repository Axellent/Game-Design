using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game_Engine{

	/* Author: Axel Sigl
	* Mediator for the game engine. */
	public class GameEngine : Game, IObservable<List<Texture2D>>, IObservable<GameTime>{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		RenderManager renderManager;
		InputManager inputManager;
		SceneManger sceneManager;
		PhysicsManager physicsManager;
		SoundManager soundManager;
		List<Entity> entities;
		List<Texture2D> gameContent;
		IObserver<GameTime> entityObserver;
		IObserver<List<Texture2D>> contentObserver;
		List<string> contentNames;
		List<KeyBind> keyBinds = new List<KeyBind>();
		List<KeyBind> actions = new List<KeyBind>();
		List<KeyValuePair<Entity, Entity>> collisionPairs;
		List<SoundEffect> soundContent;
		List<string> soundContentNames;

		List<Tuple<Vector3,Viewport,Entity>> viewPositions = new List<Tuple<Vector3, Viewport, Entity>>();
		Vector3 curViewPos = new Vector3(0, 0, 0);

		public List<KeyBind> Actions{
			get {
				return actions;
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


		public List<Tuple<Vector3,Viewport, Entity>> ViewPositions{
			get
			{
				return viewPositions;
			}
			set{
				viewPositions = value;
			}
		}

		/* The current view position. */
		public Vector3 ViewPos{
			get{
				return curViewPos;
			}
			set{
				curViewPos = value;
			}
		}

		/* Initialises graphics, content, managers, and entities.*/
		public GameEngine(int controllers){
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			renderManager = new RenderManager(graphics);
			inputManager = new InputManager(controllers);
			sceneManager = new SceneManger();
			physicsManager = new PhysicsManager();
			soundManager = new SoundManager();

			entities = new List<Entity>();
		}

		public void ClearEntities(){
			entities.Clear ();
		}

		public void SetMouseVisibility(bool visible){
			IsMouseVisible = visible;
		}

		public Rectangle GetScreenSize(){
			return GraphicsDevice.PresentationParameters.Bounds;
		}

		public void ClearViewPositions(){
			viewPositions.Clear ();
		}

		public void configureEntity(Vector3 velocity, float rotation, string entityID){
			moveEntity (velocity, entityID);
			SetEntityRotation (rotation, entityID);
		}

		public void moveEntity(Vector3 velocity, string entityID){
			entities.Find (e => e.ID.Equals (entityID)).Velocity = velocity;
		}
			
		public void SetEntityRotation(float rotation, string entityID){
			entities.Find (e => e.ID.Equals (entityID)).Rotation = rotation;
		}

		public void AddTextureOnEntity(string textureName, string entityID){
			RenderedEntity rendered = (RenderedEntity)entities.Find (e => e.ID.Equals (entityID));
			rendered.Texture = gameContent.Find (t => t.Name.Equals (textureName));
		}

		public void AddEntity(Entity entity){
			entities.Add (entity);
		}

		public IDisposable Subscribe (IObserver<GameTime> observer){
			this.entityObserver = observer;
			return new Unsubscriber<IObserver<GameTime>>(observer);
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
			collisionPairs = new List<KeyValuePair<Entity, Entity>>();

			gameContent = renderManager.LoadContent(Content, contentNames);
			contentNames.Clear ();

			soundContent = soundManager.LoadContent (Content, soundContentNames);
			soundContentNames.Clear ();

			contentObserver.OnNext(GameContent);
			playBackgroundSound (soundContent.Find(s => s.Name.Equals("Sound/DaySound_02")), true);

			base.LoadContent();
		}

		public void playBackgroundSound(SoundEffect soundEffect, bool isLooped){
			soundManager.playBackgroundSound (soundEffect, isLooped);
		}

		/* Handles updates to input and physics. Also defines the BoundingBox limits for active entities.
		 * Overrides the default MonoGame Update method. */
		protected override void Update(GameTime gameTime){
			actions = inputManager.HandleInput(keyBinds);
			entityObserver.OnNext(gameTime);
			foreach(Tuple<Vector3,Viewport, Entity> pair in viewPositions) {
				GraphicsDevice.Viewport = pair.Item2;
				curViewPos = pair.Item1;

				BoundingBox limitBox = new BoundingBox(new Vector3(curViewPos.X, curViewPos.Y, 0),
					new Vector3(curViewPos.X + GraphicsDevice.Viewport.Width + 100,
						curViewPos.Y + GraphicsDevice.Viewport.Height + 100, 0));
				entities = sceneManager.RemoveFarawayEntities(entities, limitBox);
			}

			foreach(Tuple<Vector3,Viewport, Entity> pair in viewPositions) {
				GraphicsDevice.Viewport = pair.Item2;
				curViewPos = pair.Item1;

				BoundingBox limitBox = new BoundingBox(new Vector3(curViewPos.X, curViewPos.Y, 0),
					new Vector3(curViewPos.X + GraphicsDevice.Viewport.Width + 100,
						curViewPos.Y + GraphicsDevice.Viewport.Height + 100, 0));
				entities = sceneManager.RestoreSavedEntities(entities, limitBox);
			}
			physicsManager.UpdatePhysics (entities);
			contentObserver.OnNext(GameContent);
			entityObserver.OnCompleted();
			base.Update(gameTime);
		}

		/* Loads all content in contentNames. 
		 * Overrides the default MonoGame LoadContent method.*/
		protected override void Draw(GameTime gameTime){
			List<RenderedEntity> rendered = sceneManager.SortRenderedEntities(entities);
			renderManager.Draw (spriteBatch, GraphicsDevice, curViewPos, rendered, viewPositions);
			base.Draw (gameTime);
		}
	}
}
