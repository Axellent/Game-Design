using System;

using System.Collections.Generic;
using Game_Engine;

namespace Survival_Game
{
	public class CollisionObserver : IObserver<List<KeyValuePair<Entity, Entity>>>
	{
		private IDisposable removeableObserver;

		public CollisionObserver ()
		{
		}

		public void AddDisposableObserver (IDisposable disposableObserver){
			removeableObserver = disposableObserver;
		}

		public void OnNext (List<KeyValuePair<Entity, Entity>> value)
		{
			if (value != null) {
				foreach (KeyValuePair<Entity, Entity> collisionPair in value) {
					Player player = (Player)collisionPair.Key;
					if (!player.IsMoving)
						player = (Player)collisionPair.Value;
					player.IsMoving = false;
					Console.WriteLine ("Max.X: " + player.HitBox.Max.X);
					Console.WriteLine ("Max.Y: " + player.HitBox.Max.Y + "\n");
					Console.WriteLine ("Min.X: " + player.HitBox.Min.X);
					Console.WriteLine ("Min.Y: " + player.HitBox.Min.Y + "\n");
				}
			}
		}

		public void checkCollision(KeyValuePair<Entity, Entity> collisionPair){
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

