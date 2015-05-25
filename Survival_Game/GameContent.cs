using System;
using System.IO;
using System.Text;

using Game_Engine;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game{
	
	//author: Rasmus Bäckerhall
	public class GameContent{

		public GameContent (){
			
		}

		//defines the content that should be loaded by the engine
		public List<string> LoadGameContent(){
			List<string> gameContent = new List<string>();
			gameContent.Add("tile_1");
			gameContent.Add("tile_2");
			gameContent.Add("player_s");
			gameContent.Add("player_r");
			gameContent.Add("player_l");
			gameContent.Add ("Menu");
			gameContent.Add ("OptionsButton");
			gameContent.Add ("PlayButton");
			gameContent.Add ("ExitButton");
			gameContent.Add ("BackButton");
			gameContent.Add ("OptionsButtonP");
			gameContent.Add ("PlayButtonP");
			gameContent.Add ("ExitButtonP");
			gameContent.Add ("BackButtonP");
			return gameContent;
		}

		public List<string> LoadSoundContent(){
			List<string> soundContent = new List<string> ();
			string[] str = Directory.GetFiles (Directory.GetCurrentDirectory () + "\\Content\\Sound");
			string[] dir = new string[56];
			string[] temp = new string[1];
			temp [0] = "Content\\";
			int i = 0;
			foreach (string s in str) {
				if (s.Split('.')[1].Equals("xnb")){
					dir[i] = s.Split (temp, StringSplitOptions.RemoveEmptyEntries)[1].Split('.')[0];
					dir[i] = dir[i].Replace('\\', '/');
					soundContent.Add (dir [i]);
					i++;
				}
			}
			return soundContent;
		}

		public List<KeyBind> MenuKeyBindSetup(){
			List<KeyBind> keybinds = new List<KeyBind> ();

			KeyBind keybind1 = new KeyBind ();
			keybind1.EntityID = "none";
			keybind1.Keys.Add ("Up");
			keybind1.Action = "up";
			KeyBind keybind2 = new KeyBind ();
			keybind2.EntityID = "none";
			keybind2.Keys.Add ("Down");
			keybind2.Action = "down";
			KeyBind keybind3 = new KeyBind ();
			keybind3.EntityID = "none";
			keybind3.Keys.Add ("Enter");
			keybind3.Action = "enter";

			keybinds.Add (keybind1);
			keybinds.Add (keybind2);
			keybinds.Add (keybind3);

			return keybinds;
		}

		//Keyboard Setup 1 
		public List<KeyBind> DefineKeybindingsSetup1(string playerID){
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

		//Keyboard Setup 2
		public List<KeyBind> DefineKeybindingsSetup2(string playerID){
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

		//gamePad setup
		public List<KeyBind> DefineKeybindingsForGamePad(string playerID){
			List<KeyBind> keybinds = new List<KeyBind> ();
			KeyBind keybind1 = new KeyBind ();
			keybind1.Keys.Add ("up");
			keybind1.Keys.Add (playerID);
			keybind1.Keys.Add ("up");
			keybind1.IsController = true;
			KeyBind keybind2 = new KeyBind ();
			keybind2.Keys.Add ("left");
			keybind2.Keys.Add (playerID);
			keybind2.Keys.Add ("left");
			keybind2.IsController = true;
			KeyBind keybind3 = new KeyBind ();
			keybind3.Keys.Add ("down");
			keybind3.Keys.Add (playerID);
			keybind3.Keys.Add ("down");
			keybind3.IsController = true;
			KeyBind keybind4 = new KeyBind ();
			keybind4.Keys.Add ("right");
			keybind4.Keys.Add (playerID);
			keybind4.Keys.Add ("right");
			keybind4.IsController = true;
			KeyBind keybind5 = new KeyBind ();
			keybind5.Keys.Add ("x");
			keybind5.Keys.Add (playerID);
			keybind5.Keys.Add ("action");
			keybind5.IsController = true;

			keybinds.Add (keybind1);
			keybinds.Add (keybind2);
			keybinds.Add (keybind3);
			keybinds.Add (keybind4);
			keybinds.Add (keybind5);

			return keybinds;
		}
	}
}