using System;
using System.Collections.Generic;
using Survival_Game;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: 3 buttons for optionmenu, playmenu and exit. 
	public class StartMenu
	{
		/*private Texture2D menuTexture;
		private Rectangle menuRect;
		private String assetName;*/
		GameEngine engine;
		private Button play, options, exit;
		//List<GUIElement> main = new List<GUIElement>;

		public StartMenu (GameEngine engine){

			this.engine = engine;
			//play = new Button("Play Game", engine.getScreenSize().X/2 - 100, engine.getScreenSize().Y/2 - 100, );
			//Content.RootDirectory = "Content";
		}

		public void LoadMenu(List<Entity> entities){
		}

		public void LoadContent(){
			
			/*menuTexture = content.Load<Texture2D> (assetName);
			menuRect = new Rectangle(0, 0, menuTexture.Width, menuTexture.Height);*/
		}

		public void Update(){

		}

		public void Draw(SpriteBatch spritebatch){
			/*spritebatch.Begin();
			spritebatch.Draw(menuTexture, menuRect, Color.Black);
			spritebatch.End();*/
		}
		//TODO: add functionality for button click... might be moved to MenuController
	}
}

