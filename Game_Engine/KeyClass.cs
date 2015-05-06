using System;
using System.Collections;

using Microsoft.Xna.Framework.Input;

namespace Game_Engine
{
	public class KeyClass : IEnumerable
	{
		private Keys[] keysCollection;

		public KeyClass (Keys[] keysCollection)
		{
			this.keysCollection = keysCollection;
		}
			 
		public IEnumerator GetEnumerator ()
		{
			return (IEnumerator)this;
		}

	}
}

