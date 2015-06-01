using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Game_Engine
{
	//author: Andreas Lönnermark
	public class KeyBind <T>
	{

		private T key;
		private string action;
		private string entityID;
		private int controllerIndex;

		public T Key{
			get{ 
				return key;
			}
			set{
				key = value;
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

		public int ControllerIndex {
			get {
				return controllerIndex;
			}
			set {
				controllerIndex = value;
			}
		}

		public KeyBind ()
		{
			//keys = new T ();
		}
	}
}

