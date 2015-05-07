using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Survival_Game
{
	public class EmptyClass
	{

		public Matrix transform;
		Vector2 centre;

		public EmptyClass ()
		{
		}

		public void Update(Vector2 position){
			centre = new Vector2 (position.X - 200, position.Y - 250);
			transform = Matrix.CreateScale (new Vector3 (1, 1, 0)) *
			Matrix.CreateTranslation (new Vector3 (-centre.X, -centre.Y, 0));
		}
	}
}

