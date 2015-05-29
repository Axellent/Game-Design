using System;
using System.Windows.Forms;
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

		public OptionMenu(GameEngine engine){
			this.engine = engine;
			float btnXPos = engine.GetScreenSize ().Width / 2;
			float btnYPos = engine.GetScreenSize ().Height / 2;
			
			backBtn = new Button ("backBtn", btnXPos, btnYPos, 150, 50, 0, 
				new BoundingBox (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0)), 1, null, false, false);

			menu = new RenderedEntity ("menu", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 600, 480, 0, 
				new BoundingBox(), 0, null, false);

			volume = new OptionBar("masterVolume", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 165, 24, 0, 
				new BoundingBox(), 1, null, 10);

			fullscreen = new CheckBox("fullscreen", engine.GetScreenSize().Width / 2, engine.GetScreenSize().Height / 2, 20, 20, 0, 
				new BoundingBox(), 1, null);
		}

		public void CreateMenu(){
			//engine.ViewPositions.Add (new Tuple<Vector3, Viewport, Entity> (new Vector3 (0, 0, 0), engine.GraphicsDevice.Viewport, null));
			engine.AddEntity(backBtn);
			engine.AddEntity(volume);
			engine.AddEntity(menu);
			engine.AddEntity(fullscreen);
		}

		public void AddOptionButtonListener(){

		}

		public void AddBackButtonListener(Button.buttonPressed buttonListener){
			backBtn.pressed += buttonListener;
		}
	}
}