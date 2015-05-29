using System;
using Game_Engine;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	public class GameMenu
	{
		private GameEngine engine;
		private Button saveBtn, exitBtn, optionBtn, resumeBtn;
		private RenderedEntity menu;

		public GameMenu (GameEngine engine)
		{
			this.engine = engine;
			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;

			resumeBtn = new Button ("resumeBtn", btnXPos, btnYPos - 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false);

			saveBtn = new Button ("saveBtn", btnXPos, btnYPos - 100, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false);

			optionBtn = new Button ("optionBtn", btnXPos, btnYPos, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false);

			exitBtn = new Button ("exitBtn", btnXPos, btnYPos + 100, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false);

			menu = new RenderedEntity ("menu", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);		
		}

		public void createMenu(){
			engine.AddEntity (resumeBtn);
			engine.AddEntity (saveBtn);
			engine.AddEntity (optionBtn);
			engine.AddEntity (exitBtn);
			engine.AddEntity (menu);
		}

		public void AddResumeBtnListener(Button.buttonPressed buttonListener){
			resumeBtn.pressed += buttonListener;
		}
	}
}

