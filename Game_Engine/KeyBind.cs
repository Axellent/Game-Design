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
			
		private List<string> keys;
		private String action;

		public List<string> Keys{
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
			keys = new List<string> ();
		}
	}
}

