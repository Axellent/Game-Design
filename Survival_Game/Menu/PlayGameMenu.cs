using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Game_Engine;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: Choose how many players want to play, a back-button and playbutton.
	public class PlayGameMenu
	{
		private GameEngine engine;
		private Button backBtn, playBtn;

		public PlayGameMenu(GameEngine engine){
			this.engine = engine;
			//backBtn = new Button("playBtn", engine.getScreenSize().Width/2 - 100, engine.getScreenSize().Height/2 - 100)
		}
				
		public void Update(){
			
		}

		//TODO: draw PlayGameMenu
		public void Draw(){

		}

		public void AddBackBtnListener(Button.click buttonclick){
			backBtn.clicked += buttonclick;
		}

		public void AddPlayBtnListener(Button.click buttonclick){
			playBtn.clicked += buttonclick;
		}
	}
}
