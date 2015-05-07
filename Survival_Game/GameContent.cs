using System;
using Game_Engine;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game{
	public class GameContent{

		public GameContent (){
			
		}

		public List<string> LoadGameContent(){
			List<string> gameContent = new List<string>();
			gameContent.Add ("player_s");
			gameContent.Add ("player_r");
			gameContent.Add ("player_l");
			return gameContent;
		}

		public List<KeyBind> DefineKeybindingSetup1(string playerID){
			List<KeyBind> keybinds = new List<KeyBind> ();
			KeyBind keybind1 = new KeyBind ();
			keybind1.Keys.Add ("w");
			keybind1.Keys.Add ("W");
			keybind1.EntityID = playerID;
			keybind1.Action = "up";
			KeyBind keybind2 = new KeyBind ();
			keybind2.Keys.Add ("a");
			keybind2.Keys.Add ("A");
			keybind2.EntityID = playerID;
			keybind2.Action = "left";
			KeyBind keybind3 = new KeyBind ();
			keybind3.Keys.Add ("s");
			keybind3.Keys.Add ("S");
			keybind3.EntityID = playerID;
			keybind3.Action = "down";
			KeyBind keybind4 = new KeyBind ();
			keybind4.Keys.Add ("d");
			keybind4.Keys.Add ("D");
			keybind4.EntityID = playerID;
			keybind4.Action = "right";
			KeyBind keybind5 = new KeyBind ();
			keybind5.Keys.Add ("f");
			keybind5.Keys.Add("F");
			keybind5.EntityID = playerID;
			keybind5.Action = "action";

			keybinds.Add(keybind1);
			keybinds.Add(keybind2);
			keybinds.Add(keybind3);
			keybinds.Add(keybind4);
			keybinds.Add(keybind5);

			return keybinds;
		}

		public List<KeyBind> DefineKeybindSetup2(string playerID){
			List<KeyBind> keybinds = new List<KeyBind> ();
			KeyBind keybind1 = new KeyBind ();
			keybind1.Keys.Add ("i");
			keybind1.Keys.Add ("I");
			keybind1.EntityID = playerID;
			keybind1.Action = "up";
			KeyBind keybind2 = new KeyBind ();
			keybind2.Keys.Add ("j");
			keybind2.Keys.Add ("J");
			keybind2.EntityID = playerID;
			keybind2.Action = "left";
			KeyBind keybind3 = new KeyBind ();
			keybind3.Keys.Add ("k");
			keybind3.Keys.Add ("K");
			keybind3.EntityID = playerID;
			keybind3.Action = "down";
			KeyBind keybind4 = new KeyBind ();
			keybind4.Keys.Add ("l");
			keybind4.Keys.Add ("L");
			keybind4.EntityID = playerID;
			keybind4.Action = "right";
			KeyBind keybind5 = new KeyBind ();
			keybind5.Keys.Add ("Add");
			keybind5.EntityID = playerID;
			keybind5.Action = "action";

			keybinds.Add(keybind1);
			keybinds.Add(keybind2);
			keybinds.Add(keybind3);
			keybinds.Add(keybind4);
			keybinds.Add(keybind5);

			return keybinds;
		}

		public void DefineKeybindingForGamePad(int playerID){
			KeyBind keybinding = new KeyBind ();
			keybinding.IsController = true;
			keybinding.Keys.Add ("up");
			keybinding.Keys.Add ("left");
			keybinding.Keys.Add ("down");
			keybinding.Keys.Add ("right");
			keybinding.Keys.Add ("x");
		}

		/*public void CreatePlayerBindings(int controllerSetup, string player)
		{
			
			if (controllerSetup == 1) {
				DefineKeybindingSetup1 (player);
			} else if (controllerSetup == 2) {
				DefineKeybindingSetup2 (player);
			} else
				DefineKeybindingForGamePad (player); 
		}*/
	}
}

