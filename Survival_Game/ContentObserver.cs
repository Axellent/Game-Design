﻿using System;
using Game_Engine;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Survival_Game
{
	public class ContentObserver : IObserver<List<Texture2D>>
	{
		private GameEngine engine;
		private EntityObserver observer;
		private IDisposable removeableObserver;
		private List<Player> players;

		public List<Player> Players {
			get {
				return players;
			}
			set {
				players = value;
			}
		}

		public ContentObserver (GameEngine engine, EntityObserver observer)
		{
			this.players = new List<Player> ();
			this.engine = engine;
			this.observer = observer;
		}

		public void AddDisposableOBserver(IDisposable disposableObserver){
			removeableObserver = disposableObserver;
		}
			
		public void OnNext (List<Texture2D> value)
		{
			foreach (Player player in players){
				AnimatedEntity e = (AnimatedEntity) engine.Entities.Find (x => x.ID.Equals (player.Name));
				if (e.Texture != null) {
					if (player.IsMoving) {
						if (e.Texture.Name.Equals("player_r")) {
							e.Texture = value.Find (x => x.Name.Equals ("player_l"));
						} else if (e.Texture.Name.Equals ("player_l")) {
							e.Texture = value.Find (x => x.Name.Equals ("player_r"));
						} else
							e.Texture = value.Find (x => x.Name.Equals ("player_r"));
					} else
						e.Texture = value.Find (x => x.Name.Equals ("player_s"));
				} else
					e.Texture = value.Find (x => x.Name.Equals ("player_s"));
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
