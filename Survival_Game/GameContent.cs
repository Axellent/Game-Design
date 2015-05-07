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
			List<string> gameContent;
			gameContent.Add ("player_s");
			gameContent.Add ("player_r");
			gameContent.Add ("player_l");
			return gameContent;
		}

		public void DefineKeybindingSetup1(string player){
			KeyBind keybinding = new KeyBind ();
			keybinding.Keys.Add("up","W");
			keybinding.Keys.Add ("left","A");
			keybinding.Keys.Add ("down","S");
			keybinding.Keys.Add ("right","D");
			keybinding.Keys.Add ("action","F");
			keyBindings.Add (player, keybinding);
		}

		public void DefineKeybindingSetup2(string player){
			KeyBind keybinding = new KeyBind ();
			keybinding.Keys.Add ("up", "I");
			keybinding.Keys.Add ("left","J");
			keybinding.Keys.Add ("down","K");
			keybinding.Keys.Add ("right","L");
			keybinding.Keys.Add ("action","Add");
			keyBindings.Add (player, keybinding);
		}

		public void DefineKeybindingForGamePad(string player){
			KeyBind keybinding = new KeyBind ();
			keybinding.IsController = true;
			keybinding.Keys.Add ("up", "Up");
			keybinding.Keys.Add ("left","Left");
			keybinding.Keys.Add ("down","Down");
			keybinding.Keys.Add ("right","Right");
			keybinding.Keys.Add ("action","X");
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

