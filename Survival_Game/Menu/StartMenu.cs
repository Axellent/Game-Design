﻿using System;
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
		private Texture2D menuTexture;
		private Rectangle menuRect;
		private String assetName;
		//List<GUIElement> main = new List<GUIElement>;

		public StartMenu (String assetName){
			this.assetName = assetName;
			//Content.RootDirectory = "Content";
		}

		public void LoadContent(ContentManager content){
			menuTexture = content.Load<Texture2D> (assetName);
			menuRect = new Rectangle(0, 0, menuTexture.Width, menuTexture.Height);
		}

		public void Update(){

		}

		public void Draw(SpriteBatch spritebatch){
			spritebatch.Draw(menuTexture, menuRect, Color.Black);
		}
		//TODO: add functionality for button click... might be moved to MenuController
	}
}

