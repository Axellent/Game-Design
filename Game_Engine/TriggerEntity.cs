using System;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class TriggerEntity : Entity{

		public TriggerEntity(string id, float x, float y, float width, float height, float rotation, BoundingBox hitbox)
			: base(id, x, y, width, height, rotation, hitbox){
		}
	}
}