using System;
using Game_Engine;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	public class ContentObserver : IObserver<List<Texture2D>>
	{
		private GameEngine engine;
		private IDisposable removeableObserver;
		private GameState currentGameState;

		const int nTileTypes = 2;

		public ContentObserver (GameEngine engine, ref GameState currentGameState)
		{
			this.engine = engine;
			this.currentGameState = currentGameState;
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
			for (int i = 0; i < engine.Entities.Count; i++) {
				if (engine.Entities [i].GetType () == typeof(Player)) {
					HandlePlayerContent (value, i);
				} else if (engine.Entities [i].GetType () == typeof(Tile)) {
					Tile tile = (Tile)engine.Entities [i];

					if (tile.Texture == null) {
						Random r = new Random (int.Parse (Guid.NewGuid ().ToString ().Substring (0, 8),
							           System.Globalization.NumberStyles.HexNumber));
						int randInt = r.Next (1, nTileTypes + 1);
						tile.Texture = value.Find (x => x.Name.Equals ("tile_" + randInt));
					}
					engine.Entities [i] = tile;
				}
				if (engine.Entities [i].GetType () == typeof(HealthBar)){
					HealthBar healthBar = (HealthBar)engine.Entities [i];
					if(healthBar.Texture == null){
						engine.AddTextureOnEntity ("health_Bar", healthBar.ID);
					}
				}
				if (engine.Entities [i].GetType () == typeof(HungerBar)){
					HungerBar hungerBar = (HungerBar)engine.Entities [i];
					if(hungerBar.Texture == null){
						engine.AddTextureOnEntity ("hunger_Bar", hungerBar.ID);
					}
				}
				if (engine.Entities [i].GetType () == typeof(Bush)) {
					Bush bush = (Bush)engine.Entities [i];

					if (bush.Texture == null) {
						bush.Texture = value.Find (x => x.Name.Equals ("bush_2"));
					}
					//engine.Entities [i] = bush;
					if(bush.IsUsed){
						engine.AddTextureOnEntity ("bush_1", bush.ID);
					}
				} else if (engine.Entities [i].GetType () == typeof(Button)) {
					Button button = (Button)engine.Entities [i];

					switch (button.ID) {
					case "playBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("PlayButton", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("PlayButton_Y", button.ID);
						}
						break;
					case "backBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("BackButton", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("BackButton_Y", button.ID);
						}
						break;
					case "optionsBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("OptionsButton", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("OptionsButton_Y", button.ID);
						}
						break;
					case "exitBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("ExitButton", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("ExitButton_Y", button.ID);
						}
						break;
					case "resumeBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("Resume", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("Resume_Y", button.ID);
						}
						break;
					case "saveBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("Save", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("Save_Y", button.ID);
						}
						break;
					case "exitMenuBtn":
						if (button.Texture == null || !button.IsHighlighted) {
							engine.AddTextureOnEntity ("ExitMenuButton", button.ID);
						} else if (button.IsHighlighted) {
							engine.AddTextureOnEntity ("ExitMenuButton", button.ID);
						}
						break;
					}
				} else if (engine.Entities [i].GetType () == typeof(CheckBox)) {
					CheckBox checkBox = (CheckBox)engine.Entities [i];
					if (checkBox.Texture == null || !checkBox.IsHighlighted) {
						if (!checkBox.IsChecked)
							engine.AddTextureOnEntity ("CheckBox", checkBox.ID);
						else
							engine.AddTextureOnEntity ("CheckBox_C", checkBox.ID);
					} else if (checkBox.IsHighlighted) {
						if (!checkBox.IsChecked)
							engine.AddTextureOnEntity ("CheckBox_Y", checkBox.ID);
						else
							engine.AddTextureOnEntity ("CheckBox_C_Y", checkBox.ID);
					} 
				} else if (engine.Entities [i].GetType () == typeof(RenderedEntity)) {
					RenderedEntity rendEnt = (RenderedEntity)engine.Entities [i];
					if (rendEnt.Texture == null) {
						engine.AddTextureOnEntity ("Menu", rendEnt.ID);
					}
				} else if (engine.Entities [i].GetType () == typeof(OptionBar)) {
					OptionBar optionBar = (OptionBar)engine.Entities [i];
					HandleOptionBar (optionBar);
				}
			}
		}

		public void HandleOptionBar(OptionBar optionBar){
			if (!optionBar.IsHighlighted)
				engine.AddTextureOnEntity ("Bars", optionBar.ID);
			else
				engine.AddTextureOnEntity ("Bars_Y", optionBar.ID);
			int x = optionBar.TenPercentage * (engine.GetTextureWidth("Bars") / 11);
			int width = engine.GetTextureWidth ("Bars") / 11;
			int height = engine.GetTextureHeight ("Bars");
			switch (optionBar.TenPercentage) {
			case 0:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 1:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 2:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 3:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 4:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 5:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 6:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 7:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 8:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 9:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			case 10:
				if (optionBar.Texture == null || !optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				} else if (optionBar.IsHighlighted) {
					engine.HandleSpriteSheet (optionBar.ID, new Rectangle(x, 0, width, height));
				}
				break;
			}
		}

		public void HandlePlayerContent(List<Texture2D> texture, int index){
			Player player = (Player)engine.Entities[index];

			if (player.Texture != null) {
				if (player.IsMoving) {
					if (player.Texture.Name.Equals ("player_r") && player.FootTicker >= 10) {
						player.FootTicker = 0;
						player.Texture = texture.Find (x => x.Name.Equals ("player_l"));
					} else if (player.Texture.Name.Equals ("player_l") && player.FootTicker >= 10) {
						player.FootTicker = 0;
						player.Texture = texture.Find (x => x.Name.Equals ("player_r"));
					} else if (player.FootTicker == 0)
						player.Texture = texture.Find (x => x.Name.Equals ("player_r"));
					player.FootTicker += player.MovementSpeed / 4;
				} else if (!player.Texture.Name.Equals ("player_s")) {
					player.FootTicker = 0;
					player.Texture = texture.Find (x => x.Name.Equals ("player_s"));
				} else if (player.IsUsing){
					player.Texture = texture.Find (x => x.Name.Equals ("player_L_Hand"));
				}
			}
			else {
				player.Texture = texture.Find(x => x.Name.Equals("player_s"));
			}
			engine.Entities[index] = player;
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

