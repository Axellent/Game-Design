using System;
using Game_Engine;
using System.Collections.Generic;

namespace Survival_Game
{
	public class ObjectObserver : IObserver<KeyBind>
	{
		float playerSpeed = 2.0F;
		GameEngine engine;
		List<string> playersByID;
		private IDisposable removableObserver;

		public ObjectObserver (GameEngine engine)
		{
			playersByID = new List<string> ();
			this.engine = engine;
		}

		public void AddDisposableOBserver(IDisposable disposableObserver){
			removableObserver = disposableObserver;
		}

		public void Unsubscribe()
		{
			removableObserver.Dispose();
			playersByID.Clear();
		}

		public void OnNext (KeyBind value)
		{
			Entity entity = engine.Entities.Find (x => x.ID.Equals (value.EntityID));
			switch (value.Action) {
			case "up":
				entity.Y -= playerSpeed;
				break;
			case "down":
				entity.Y += playerSpeed;
				break;
			case "left":
				entity.X += playerSpeed;
				break;
			case "right":
				entity.X -= playerSpeed;
				break;
			case "action":
				break;
			}
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