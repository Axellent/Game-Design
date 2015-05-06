using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Game_Engine
{
	public class KeyBind
	{
		private List<String> keys;
		private String action;

		public List<String> Keys{
			get{ 
				return keys;
			}
			set{
				keys = value;
			}
		}

		public String Action{
			get{
				return action;
			}
			set{
				action = value;
			}
		}

		public KeyBind ()
		{
		}
	}
}

