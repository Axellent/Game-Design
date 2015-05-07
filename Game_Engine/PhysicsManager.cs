using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class PhysicsManager : IObservable<Entity>{
		private IObserver<Entity> observer;
		private bool collision = false;

		public PhysicsManager(){

		}

		public bool Collision {
			get {
				return collision;
			}
			set {
				collision = value;
			}
		}
				
		public void UpdatePhysics(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs;

			collisionPairs = CollisionDetection(entities);
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

		public void OnNext(){
			throw new NotImplementedException();
		}

		public void OnError(){
			throw new NotImplementedException();
		}

		public void OnCompleted(){
			throw new NotImplementedException();
		}

		public List<KeyValuePair<Entity, Entity>> CollisionDetection(List<Entity> entities){
			List<KeyValuePair<Entity, Entity>> collisionPairs = new List<KeyValuePair<Entity, Entity>>();

			foreach (Entity e1 in entities) {
				foreach (Entity e2 in entities) {
					if (e1.HitBox.Intersects (e2.HitBox))
						collisionPairs.Add(new KeyValuePair<Entity, Entity> (e1, e2));
				}
			}

			return collisionPairs;
		}
	}
}

