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
	public class StartMenu : RenderedEntity
	{
		/*private Texture2D menuTexture;
		private Rectangle menuRect;
		private String assetName;*/
		GameEngine engine;
		List<Button> buttons;
		private Button play, options, exit;
		//List<GUIElement> main = new List<GUIElement>;

		public StartMenu (string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, GameEngine engine) 
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){

			this.engine = engine;
			buttons = new List<Button>();
			//play = new Button("Play Game", engine.getScreenSize().X/2 - 100, engine.getScreenSize().Y/2 - 100, );
			//Content.RootDirectory = "Content";
		}

		public void LoadMenu(List<Entity> entities){
			engine.addEntity(this);
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
		public MenuController.Menu OnClick(string element){

			if (element.Equals ("Omenu"))
				return MenuController.Menu.OptionMenu;
			else if (element.Equals ("PMenu"))
				return MenuController.Menu.PlayGameMenu;

			return MenuController.Menu.None;
		}
	}
}

