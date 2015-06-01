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
		private Button backBtn, playBtn, player1Btn, player2Btn, player3Btn, player4Btn;
		private RenderedEntity menu;

		public PlayGameMenu(GameEngine engine){
			this.engine = engine;

			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;

			player1Btn = new Button ("player1Btn", btnXPos - 100, btnYPos - 100, 100, 100, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 0);

			player2Btn = new Button ("player2Btn", btnXPos + 100, btnYPos - 100, 100, 100, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 1);

			player3Btn = new Button ("player3Btn", btnXPos - 100, btnYPos + 50, 100, 100, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 2);

			player4Btn = new Button ("player4Btn", btnXPos + 100, btnYPos + 50, 100, 100, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 3);

			playBtn = new Button("playBtn", btnXPos + 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false, 0);

			backBtn = new Button ("backBtn", btnXPos - 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, true, 1);

			menu = new RenderedEntity ("menu", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);
		}

		public void CreateMenu(){
			engine.AddEntity (player1Btn);
			engine.AddEntity (player2Btn);
			engine.AddEntity (player3Btn);
			engine.AddEntity (player4Btn);
			engine.AddEntity (backBtn);
			engine.AddEntity (playBtn);
			engine.AddEntity (menu);
		}

		public void AddPlayerBtnsListeners(Button.entitySelected buttonclick){
			player1Btn.playerSelected += buttonclick;
			player2Btn.playerSelected += buttonclick;
			player3Btn.playerSelected += buttonclick;
			player4Btn.playerSelected += buttonclick;
		}

		public void AddBackBtnListener(Button.entitySelected buttonclick){
			backBtn.selected += buttonclick;
		}

		public void AddPlayBtnListener(Button.entitySelected buttonclick){
			playBtn.selected += buttonclick;
		}
	}
}
