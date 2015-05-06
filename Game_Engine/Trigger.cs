using System;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	/* Author: Axel Sigl */
	public class Trigger : Entity{

		public Trigger(float x, float y, float width, float height, float rotation, BoundingBox hitbox)
			: base(x, y, width, height, rotation, hitbox){
		}
	}
}

