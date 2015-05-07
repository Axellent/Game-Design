using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Game_Engine
{
	public class KeyBind
	{
		private bool isController=false;

		public bool IsController {
			get {
				return isController;
			}
			set {
				isController = value;
			}
		}

		private Dictionary<string, string> keys;
		private String action;

		public Dictionary<string, string> Keys{
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
			keys = new Dictionary<string, string> ();
			keys.Add ("up", null);
			keys.Add ("down", null);
			keys.Add ("left", null);
			keys.Add ("right", null);
			keys.Add ("action", null);
		}
	}
}

