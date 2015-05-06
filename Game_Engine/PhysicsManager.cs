using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class PhysicsManager : IObservable<Entity>{
		private IObserver<Entity> observer;

		public PhysicsManager(){

		}
				
		public void UpdatePhysics(List<Entity> entities){
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

		public void CollisionDetection(){
			
		}
	}
}

