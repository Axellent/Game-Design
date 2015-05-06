using System;
using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game
{
	public class ObjectObserver : IObserver<Entity>
	{
		List<string> playersByID;
		private IDisposable removableObserver;

		public ObjectObserver ()
		{
			playersByID = new List<string> ();
		}

		public void Unsubscribe()
		{
			removableObserver.Dispose();
			playersByID.Clear();
		}

		public void OnNext (Entity value)
		{
			throw new NotImplementedException ();
		}

		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}

		public void OnCompleted ()
		{
			playersByID.Clear();
		}
	}
}