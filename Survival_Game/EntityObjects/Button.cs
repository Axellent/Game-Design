using System;
using Game_Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game
{
	public class Button : TriggerEntity
	{
		private BoundingBox hitbox;
		public event click clicked;

		public void textureClicked(){
			MouseState mousestate = new MouseState ();
			BoundingBox box = new BoundingBox(new Vector3(mousestate.Position.X, mousestate.Position.Y,0), new Vector3(mousestate.Position.X, mousestate.Position.Y, 0)); 
			if (hitbox.Intersects(box)){
				clicked();
			}
		}

		public Button (string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox, int layer, Texture2D texture, bool hasCollision)
			: base(id, x, y, width, height, rotation, hitbox, layer, texture, hasCollision){
			this.hitbox = hitbox;
		}
	}
}

