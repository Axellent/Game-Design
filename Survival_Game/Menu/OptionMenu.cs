using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survival_Game
{
	//author: Rasmus Bäckerhall
	//TODO: options for fullscreen, options for sound etc.
	public class OptionMenu : RenderedEntity
	{
		private GameEngine engine;

		public OptionMenu(string id, float x, float y, float width, float height, float rotation,
			BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision, GameEngine engine) 
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			this.engine = engine;
		}

		public void LoadContent(){
			
		}

		public void Update(){

		}

		public void Draw(){

		}
	}
}