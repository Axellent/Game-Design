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
	public class PlayGameMenu : RenderedEntity
	{
		private GameEngine engine;
		private Button backBtn, playBtn;

		/*public PlayGameMenu(GameEngine engine){
			this.engine = engine;
			//backBtn = new Button("playBtn", engine.getScreenSize().Width/2 - 100, engine.getScreenSize().Height/2 - 100)
		}*/

		public PlayGameMenu(string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, GameEngine engine) 
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			this.engine = engine;
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
