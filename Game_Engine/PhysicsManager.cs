using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class PhysicsManager : IObservable<Entity>{
		
		private List<SceneObject> sceneObjects;
		private IObserver<Entity> observer;

		public List<SceneObject> SceneObjects{
			get{
				return sceneObjects;
			}
			set{
				sceneObjects = value;
			}
		}

		public PhysicsManager(){

		}
				
		public void UpdatePhysics(Vector2 worldPos, Vector2 oldWorldPos, List<SceneObject> sceneObjects, float playerRotation){
			for(int i = 0; i < sceneObjects.Count; i++){
				if (!sceneObjects[i].Texture.Name.Equals ("player_s")) {
					sceneObjects[i].X += oldWorldPos.X - worldPos.X;
					sceneObjects[i].Y += oldWorldPos.Y - worldPos.Y;
				} else {
					sceneObjects[i].Rotation = playerRotation;
				}
			}
			this.sceneObjects = sceneObjects;
			//observer.OnNext();
		}

		public IDisposable Subscribe (IObserver<Entity> observer)
		{
			this.observer = observer;

			return new UnSubscriber (this.observer);
		}

		private class UnSubscriber : IDisposable {
			private IObserver<Entity> _observer;

			public UnSubscriber(IObserver<Entity> observer)
			{
				_observer = observer;	
			}
			public void Dispose ()
			{
				_observer = null;
			}
		}
		public void UpdatePhysics(List<Entity> entities){

		}
	}
}

