using System;
using System.Collections;
using System.Collections.Generic;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: options for fullscreen, options for sound etc.
	public class OptionMenu
	{
		private GameEngine engine;
		private Button backBtn;
		private RenderedEntity menu;
		private OptionBar volume;
		private CheckBox fullscreen;

		public OptionMenu(GameEngine engine){			this.engine = engine;
			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;
			
			backBtn = new Button ("backBtn", btnXPos - 200, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, true, 2);

			menu = new RenderedEntity ("menu", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 600, 480, 0, 
			volume = new OptionBar("masterVolume", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2 - 100, 165, 24, 0, 
				new BoundingBox(), 1, null, false, false, 10, 0, new Rectangle(0,0,0,0));

			fullscreen = new CheckBox("fullscreen", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2 + 0, 20, 20, 0, 
				new BoundingBox(), 1, null, false, false, 1);
		}

		public void CreateMenu(){
			//engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (0, 0, 0), engine.GraphicsDevice.Viewport, null));
			engine.AddEntity(backBtn);
			engine.AddEntity(volume);
			engine.AddEntity(menu);
			engine.AddEntity(fullscreen);
		}

		public void AddBackBtnListener(Button.entitySelected buttonListener){
			backBtn.selected += buttonListener;
		}

			
		public void AddBarListener(Button.entitySelected buttonListener){
			backBtn.selected += buttonListener;
		}
	}
}



