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

		const int nTileTypes = 2;

		public ContentObserver (GameEngine engine, EntityObserver observer)
		{
			this.engine = engine;
		}

		public void AddDisposableObserver(IDisposable disposableObserver){
			removeableObserver = disposableObserver;
		}

		//Defines which content should be ed for the specified entity
		/*TODO iteration3: First of all add more content to the game engine, but  it should also 
		 * be able to  content not only for a player but also other kinds of objects
		*/
		public void OnNext (List<Texture2D> value)
		{
			for(int i = 0; i < engine.Entities.Count; i++){
				if(engine.Entities[i].GetType() == typeof(Player)) {
					HandlePlayerContent (value, i);
				}

				else if(engine.Entities[i].GetType() == typeof(Tile)) {
					Tile tile = (Tile)engine.Entities[i];

					if(tile.Texture == null) {
						Random r = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8),
							System.Globalization.NumberStyles.HexNumber));
						int randInt = r.Next(1, nTileTypes + 1);
						tile.Texture = value.Find(x => x.Name.Equals("tile_" + randInt));
					}
					engine.Entities[i] = tile;
				}

				if(engine.Entities[i].GetType() == typeof(Bush)) {
					Bush bush = (Bush)engine.Entities[i];

					if(bush.Texture == null) {
						bush.Texture = value.Find(x => x.Name.Equals("bush_2"));
					}
					engine.Entities[i] = bush;
				}
				else if (engine.Entities [i].GetType () == typeof(Button)) {
					Button button = (Button)engine.Entities [i];

					switch (button.ID) {
					case "playBtn":
						if (button.Texture == null || !button.ButtonHighlighted) {
							engine.AddTextureOnEntity ("PlayButton", button.ID);
						} else if (button.ButtonHighlighted) {
							engine.AddTextureOnEntity ("PlayButtonP", button.ID);
						}
						break;
					case "backBtn":
						if (button.Texture == null || !button.ButtonHighlighted) {
							engine.AddTextureOnEntity ("BackButton", button.ID);
						} else if (button.ButtonHighlighted) {
							engine.AddTextureOnEntity ("BackButtonP", button.ID);
						}
							break;
					case "optionsBtn":
						if (button.Texture == null || !button.ButtonHighlighted) {
						engine.AddTextureOnEntity ("OptionsButton", button.ID);
					} else if (button.ButtonHighlighted) {
						engine.AddTextureOnEntity ("OptionsButtonP", button.ID);
					}
						break;
					case "exitBtn":
						if (button.Texture == null || !button.ButtonHighlighted) {
						engine.AddTextureOnEntity ("ExitButton", button.ID);
					} else if (button.ButtonHighlighted) {
						engine.AddTextureOnEntity ("ExitButtonP", button.ID);
					}
						break;
					}
				}
				else if (engine.Entities [i].GetType () == typeof(RenderedEntity)) {
					RenderedEntity rendEnt = (RenderedEntity)engine.Entities [i];
					if (rendEnt.Texture == null) {
						engine.AddTextureOnEntity ("Menu", rendEnt.ID);
					}
				}
			}
		}

		public void HandlePlayerContent(List<Texture2D> texture, int index){
			Player player = (Player)engine.Entities[index];

			if(player.Texture != null) {
				if(player.IsMoving) {
					if(player.Texture.Name.Equals("player_r") && player.FootTicker >= 10) {
						player.FootTicker = 0;
						player.Texture = texture.Find(x => x.Name.Equals("player_l"));
					} else if(player.Texture.Name.Equals("player_l") && player.FootTicker >= 10) {
						player.FootTicker = 0;
						player.Texture = texture.Find(x => x.Name.Equals("player_r"));
					} else if(player.FootTicker == 0)
						player.Texture = texture.Find(x => x.Name.Equals("player_r"));
					player.FootTicker += player.MovementSpeed / 4;
				} else if(!player.Texture.Name.Equals("player_s")) {
					player.FootTicker = 0;
					player.Texture = texture.Find(x => x.Name.Equals("player_s"));
				}
			} else {
				player.Texture = texture.Find(x => x.Name.Equals("player_s"));
			}
			//engine.Entities[index] = player;
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

