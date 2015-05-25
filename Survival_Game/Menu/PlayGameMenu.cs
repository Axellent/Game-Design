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

			float btnXPos = engine.getScreenSize ().Width / 2;
			float btnYPos = engine.getScreenSize ().Height / 2;
			playBtn = new Button("playBtn", btnXPos, btnYPos, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false);
			Console.WriteLine(engine.getScreenSize().Width + ", " + engine.getScreenSize().Height + ", " + 
				engine.getScreenSize().X + ", " + engine.getScreenSize().Y);
			btnXPos = engine.getScreenSize ().Width / 2;
			btnYPos = engine.getScreenSize ().Height / 2 + 100;
			backBtn = new Button ("backBtn", btnXPos, btnYPos, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false);

			//backBtn = new Button("playBtn", engine.getScreenSize().Width/2 - 100, engine.getScreenSize().Height/2 - 100)
		}
				
		public void Update(){
			menu = new RenderedEntity ("menu", engine.getScreenSize().Width / 2, engine.getScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);
		}

		public void createMenu(){
			engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (0, 0, 0), engine.GraphicsDevice.Viewport, null));
			engine.addEntity (backBtn);
			engine.addEntity (playBtn);
			engine.addEntity (menu);
		}
			
		public void AddBackBtnListener(Button.click buttonclick){
			backBtn.clicked += buttonclick;
		}

		public void AddPlayBtnListener(Button.click buttonclick){
			playBtn.clicked += buttonclick;
		}
	}
}
