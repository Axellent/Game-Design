using System;
using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game
{
	public class PlayerProvider : IObservable<ActorEntity>
	{
		private IObserver<ActorEntity> observer;
		private List<ActorEntity> players;

		public PlayerProvider ()
		{
			

		}

		//Called from the thread using the ThreadStart delegate
		public void run()
		{
			//TODO: create new player keep track of data
		}


		public IDisposable Subscribe (IObserver<ActorEntity> observer)
		{
			if (!this.observer.Equals (observer)) {
				this.observer = observer;

				foreach (var player in players)
					observer.OnNext (player);
			}
			return new Unsubscriber<ActorEntity> (observer);
		}

		private class Unsubscriber<ActorEntity> : IDisposable 
		{
			private IObserver<ActorEntity> _observer;

			public Unsubscriber(IObserver<ActorEntity> observer)
			{
				this._observer = observer;
			}

			public void Dispose ()
			{
				if (_observer != null)
					_observer = null;
			}
		}	
	}
}

