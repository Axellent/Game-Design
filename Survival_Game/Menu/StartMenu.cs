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
		GameEngine engine;
		private Button playBtn, optionsBtn, exitBtn;
		private RenderedEntity menu;

		public StartMenu (GameEngine engine){
			this.engine = engine;
			playBtn = new Button ("playBtn", engine.GetScreenSize ().Width / 2, engine.GetScreenSize ().Height / 2, 
				150, 50, 0, new BoundingBox (), 1, null, false, true);
			optionsBtn = new Button ("optionsBtn", engine.GetScreenSize ().Width / 2, engine.GetScreenSize ().Height / 2 + 100,
				150, 50, 0, new BoundingBox (), 1, null, false, false);
			exitBtn = new Button ("exitBtn", engine.GetScreenSize ().Width / 2, engine.GetScreenSize ().Height / 2 + 200, 
				150, 50, 0, new BoundingBox (), 1, null, false, false);
			menu = new RenderedEntity ("menu", engine.GetScreenSize ().Width / 2, engine.GetScreenSize ().Height / 2,
				600, 480, 0, new BoundingBox (), 0, null, false);
		}

		public void createStartMenu(){
			engine.AddEntity (playBtn);
			engine.AddEntity (optionsBtn);
			engine.AddEntity (exitBtn);
			engine.AddEntity (menu);
		}

		public void AddPlayButtonListener(Button.buttonPressed buttonListener){
			playBtn.pressed += buttonListener;
		}
			
		public void AddOptionsButtonListener(Button.buttonPressed buttonListener){
			optionsBtn.pressed += buttonListener;
		}

		public void AddExitButtonListener(Button.buttonPressed buttonListener){
			exitBtn.pressed += buttonListener;
		}
	}
}

