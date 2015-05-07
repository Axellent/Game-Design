using System;
using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game
{
	public class ObjectObserver : IObserver<Entity>
	{
		List<string> playersByID;
		List<string> actions;
		private IDisposable removableObserver;

		public ObjectObserver ()
		{
			playersByID = new List<string> ();
		}

		public void AddDisposableOBserver(IDisposable disposableObserver){
			removableObserver = disposableObserver;
		}

		public void Unsubscribe()
		{
			removableObserver.Dispose();
			playersByID.Clear();
		}

		public void OnNext (Entity value)
		{
			switch (actions [0]) {
			case "moveUp":
				break;
			case "moveDown":
				break;
			case "moveLeft":
				break;
			case "moveRight":
				break;
			case "action":
				break;
			}

			if (actions [0] == "moveUp") {

			}

			actions.RemoveAt (0);
		}

		public void AddAction (List<string> _actions){
			this.actions = _actions;
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