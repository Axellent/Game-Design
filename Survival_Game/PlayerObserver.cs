using System;
using Game_Engine;
using System.Collections.Generic;
namespace Survival_Game
{
	public class PlayerObserver : IObserver<ActorEntity>
	{
		List<string> playersByID;
		private IDisposable playerRemoval;

		public PlayerObserver ()
		{
			playersByID = new List<string> ();
		}

		private void Subscribe(PlayerProvider provider)
		{
			playerRemoval = provider.Subscribe (this);
		}

		public void Unsubscribe()
		{
			playerRemoval.Dispose();
			playersByID.Clear();
		}

		public void OnNext (ActorEntity value)
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

