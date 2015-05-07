using System;
using Game_Engine;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game{
	public class GameContent{

		Dictionary<string, KeyBind> keyBindings;

		public GameContent (){
			keyBindings = new Dictionary<string, KeyBind> ();
		}

		public List<string> LoadGameContent(){
			List<string> gameContent = new List<string>();
			gameContent.Add ("player_s");
			gameContent.Add ("player_r");
			gameContent.Add ("player_l");
			return gameContent;
		}

		public void DefineKeybindingSetup1(string player){
			KeyBind keybinding = new KeyBind ();
			keybinding.Keys.Add("w");
			keybinding.Keys.Add ("a");
			keybinding.Keys.Add ("s");
			keybinding.Keys.Add ("d");
			keybinding.Keys.Add ("f");
			keyBindings.Add (player, keybinding);
		}

		public void DefineKeybindingSetup2(string player){
			KeyBind keybinding = new KeyBind ();
			keybinding.Keys.Add ("i");
			keybinding.Keys.Add ("j");
			keybinding.Keys.Add ("k");
			keybinding.Keys.Add ("l");
			keybinding.Keys.Add ("Add");
			keyBindings.Add (player, keybinding);
		}

		public void DefineKeybindingForGamePad(string player){
			KeyBind keybinding = new KeyBind ();
			keybinding.IsController = true;
			keybinding.Keys.Add ("up");
			keybinding.Keys.Add ("left");
			keybinding.Keys.Add ("down");
			keybinding.Keys.Add ("right");
			keybinding.Keys.Add ("x");
			keyBindings.Add (player, keybinding);
		}

		public void deleteSetup(string key){
			keyBindings.Remove (key);
		}

		public void CreatePlayerBindings(int controllerSetup, string player)
		{
			
			if (controllerSetup == 1) {
				DefineKeybindingSetup1 (player);
			} else if (controllerSetup == 2) {
				DefineKeybindingSetup2 (player);
			} else
				DefineKeybindingForGamePad (player); 
		}
	}
}

