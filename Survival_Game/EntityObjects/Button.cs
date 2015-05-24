using System;
using Game_Engine;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	public class Button : TriggerEntity
	{
		public Button (string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox)
			: base(id, x, y, width, height, rotation, hitbox){
			
		}
	}
}

