using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Game_Engine;
using Survival_Game;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: Choose how many players want to play, a back-button and playbutton.
	public class PlayGameMenu
	{
		private GameEngine engine;
		private Button backBtn, playBtn;
		private RenderedEntity menu;

		public PlayGameMenu(GameEngine engine){
			this.engine = engine;

			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;
			playBtn = new Button("playBtn", btnXPos + 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, true, 0);

			backBtn = new Button ("backBtn", btnXPos - 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 1);

			menu = new RenderedEntity ("menu", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);
		}

		public void CreateMenu(){
			engine.AddEntity (backBtn);
			engine.AddEntity (playBtn);
			engine.AddEntity (menu);
		}



		public void AddBackBtnListener(Button.entitySelected buttonclick){
			backBtn.selected += buttonclick;
		}

		public void AddPlayBtnListener(Button.entitySelected buttonclick){
			playBtn.selected += buttonclick;
		}
	}
}
