using System;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Engine{
	
	public class SceneObject : EngineObject{
		private Texture2D texture;

		public Texture2D Texture{
			get{
				return texture;
			}
			set{
				texture = value;
			}
		}
		
		public SceneObject(Texture2D texture, float x, float y, float width, float height, float rotation){
			this.texture = texture;
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
	}
}

