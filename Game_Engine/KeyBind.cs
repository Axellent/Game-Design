using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Game_Engine
{
	public class KeyBind
	{

		private bool isController=false;
		private List<string> keys;
		private string action;
		private string entityID;

		public bool IsController {
			get {
				return isController;
			}
			set {
				isController = value;
			}
		}

		public List<string> Keys{
			get{ 
				return keys;
			}
			set{
				keys = value;
			}
		}

		public string Action{
			get{
				return action;
			}
			set{
				action = value;
			}
		}

		public string EntityID{
			get{
				return entityID;
			}
			set{
				entityID = value;
			}
		}

		public KeyBind ()
		{
			keys = new List<string> ();
		}
	}
}

