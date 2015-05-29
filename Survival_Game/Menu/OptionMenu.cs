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
		private RenderedEntity menu;

		public OptionMenu(GameEngine engine){
			this.engine = engine;

			float btnXPos = engine.getScreenSize ().Width / 2;
			float btnYPos = engine.getScreenSize ().Height / 2;
			
			backBtn = new Button ("backBtn", btnXPos, btnYPos, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false);

			menu = new RenderedEntity ("menu", engine.getScreenSize().Width / 2, engine.getScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);
		}

		public void LoadContent(){
			
		}

		public void Update(){

		}

		public void Draw(){

		}
	}
}