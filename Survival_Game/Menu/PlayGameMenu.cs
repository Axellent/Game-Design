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
		private Button backBtn, playBtn, player1, player2, player3, player4;
		private RenderedEntity menu;

		public PlayGameMenu(GameEngine engine){
			this.engine = engine;

			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;

//			player1 = new Button ("player1Btn", btnXPos - 200, btnYPos - 100, 150, 50, 0, 
//				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 0);
//
//			player2 = new Button ("player2Btn", btnXPos + 200, btnYPos - 100, 150, 50, 0, 
//				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 1);
//
//			player3 = new Button ("player3Btn", btnXPos - 200, btnYPos - 100, 150, 50, 0, 
//				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 2);
//
//			player4 = new Button ("player4Btn", btnXPos + 200, btnYPos - 100, 150, 50, 0, 
//				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 3);

			playBtn = new Button("playBtn", btnXPos + 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 4);

			backBtn = new Button ("backBtn", btnXPos - 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, true, 5);

			menu = new RenderedEntity ("menu", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);
		}

		public void CreateMenu(){
//			engine.AddEntity (player1);
//			engine.AddEntity (player2);
//			engine.AddEntity (player3);
//			engine.AddEntity (player4);
			engine.AddEntity (backBtn);
			engine.AddEntity (playBtn);
			engine.AddEntity (menu);
		}

		public void AddPlayer1BtnListener(Button.entitySelected buttonclicked){

		}

		public void AddBackBtnListener(Button.entitySelected buttonclick){
			backBtn.selected += buttonclick;
		}

		public void AddPlayBtnListener(Button.entitySelected buttonclick){
			playBtn.selected += buttonclick;
		}
	}
}
