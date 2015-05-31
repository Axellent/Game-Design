using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Game_Engine
{
	//author: Andreas Lönnermark
	public class KeyBind <T>
	{

		private bool isController=false;
		private List<T> keys;
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

		public List<T> Keys{
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
			keys = new List<T> ();
		}
	}
}

