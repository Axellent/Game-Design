using System;
using Game_Engine;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class ContentObserver : IObserver<List<Texture2D>>
	{
		private GameEngine engine;
		private IDisposable removeableObserver;

		public ContentObserver (GameEngine engine, EntityObserver observer)
		{
			this.engine = engine;
		}

		public void AddDisposableObserver(IDisposable disposableObserver){
			removeableObserver = disposableObserver;
		}

		//Defines which content should be loaded for the specified entity
		/*TODO iteration3: First of all add more content to the game engine, but  it should also 
		 * be able to load content not only for a player but also other kinds of objects
		*/
		public void OnNext (List<Texture2D> value)
		{
			foreach (Player player in engine.Entities){
				if (player.Texture != null) {
					if (player.IsMoving) {
						if (player.Texture.Name.Equals("player_r") && player.FootTicker>=10) {
							player.FootTicker = 0;
							player.Texture = value.Find (x => x.Name.Equals ("player_l"));
						} else if (player.Texture.Name.Equals ("player_l") && player.FootTicker>=10) {
							player.FootTicker = 0;
							player.Texture = value.Find (x => x.Name.Equals ("player_r"));
						} else if (player.FootTicker == 0)
							player.Texture = value.Find (x => x.Name.Equals ("player_r"));
						player.FootTicker += player.MovementSpeed / 4;
					} else if (!player.Texture.Name.Equals("player_s")){
						player.FootTicker = 0;
						player.Texture = value.Find (x => x.Name.Equals ("player_s"));
					}
				} else
					player.Texture = value.Find (x => x.Name.Equals ("player_s"));
			}
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

