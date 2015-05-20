using System;

using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game
{
	public class SoundObserver : IObserver<List<Entity>>
	{
		private IDisposable removeableObserver;

		public SoundObserver ()
		{
			
		}

		public void AddDisposableObserver(IDisposable disposableObserver){
			removeableObserver = disposableObserver;
		}

		public void Unsubscribe()
		{
			removeableObserver.Dispose();
		}

		public void OnNext (List<Entity> value)
		{
			
		}

		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}

		public void OnCompleted ()
		{
			throw new NotImplementedException ();
		}
	}
}

