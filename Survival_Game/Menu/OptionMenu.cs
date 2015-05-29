using System;
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

		public OptionMenu(GameEngine engine){
			this.engine = engine;
			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;
			backBtn = new Button ("backBtn", btnXPos, btnYPos + 200, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false);
		}

		public void CreateMenu(){
			
		}

		public void AddOptionButtonListener(){

		}
	}
}