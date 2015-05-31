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
//			gameContent.Add (new KeyValuePair<bool, string> (false, "tile_1"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "tile_2"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "player_s"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "player_r"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "player_l"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "Menu"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "PlayButton_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "PlayButton"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "OptionsButton_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "OptionsButton"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "ExitButton_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "ExitButton"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "bush_1"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "bush_2"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "BackButton_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "BackButton"));
//			gameContent.Add (new KeyValuePair<bool, string> (true, "Bars"));
//			gameContent.Add (new KeyValuePair<bool, string> (true, "Bars_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "Save"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "Save_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "Resume"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "Resume_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "CheckBox"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "CheckBox_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "CheckBox_C"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "CheckBox_C_Y"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "ExitMenuButton"));
//			gameContent.Add (new KeyValuePair<bool, string> (false, "ExitMenuButton_Y"));
			gameContent.Add ("tile_1");
			gameContent.Add ("tile_2");
			gameContent.Add ("player_s");
			gameContent.Add ("player_r");
			gameContent.Add ("player_l");
			gameContent.Add ("wolf_s");
			gameContent.Add ("wolf_r");
			gameContent.Add ("wolf_l");
			gameContent.Add ("Menu");
			gameContent.Add ("PlayButton_Y");
			gameContent.Add ("PlayButton");
			gameContent.Add ("OptionsButton_Y");
			gameContent.Add ("OptionsButton");
			gameContent.Add ("ExitButton_Y");
			gameContent.Add ("ExitButton");
			gameContent.Add ("bush_1");
			gameContent.Add ("bush_2");
			gameContent.Add ("BackButton_Y");
			gameContent.Add ("BackButton");
			gameContent.Add ("Bars");
			gameContent.Add ("Bars_Y");
			gameContent.Add ("Save");
			gameContent.Add ("Save_Y");
			gameContent.Add ("Resume");
			gameContent.Add ("Resume_Y");
			gameContent.Add ("CheckBox");
			gameContent.Add ("CheckBox_C");
			gameContent.Add ("CheckBox_Y");
			gameContent.Add ("CheckBox_C_Y");
			gameContent.Add ("ExitMenuButton");
			gameContent.Add ("ExitMenuButton_Y");
			gameContent.Add ("Player1");
			gameContent.Add ("Player1_S");
			gameContent.Add ("Player1_S_Y");
			gameContent.Add ("Player1_Y");
			gameContent.Add ("Player2");
			gameContent.Add ("Player2_Y");
			gameContent.Add ("Player2_S");
			gameContent.Add ("Player2_S_Y");
			gameContent.Add ("Player3");
			gameContent.Add ("Player3_Y");
			gameContent.Add ("Player3_S");
			gameContent.Add ("Player3_S_Y");
			gameContent.Add ("Player4");
			gameContent.Add ("Player4_Y");
			gameContent.Add ("Player4_S");
			gameContent.Add ("Player4_S_Y");
			gameContent.Add ("player_R_Hand");
			gameContent.Add ("player_L_Hand");
			return gameContent;
		}

		public List<string> LoadContent(string contentPath){
			List<string> content = new List<string> ();
			string[] str = Directory.GetFiles (Directory.GetCurrentDirectory () + "/" + contentPath, "*.xnb", SearchOption.TopDirectoryOnly);
			string[] dir = new string[str.Length];
			string[] temp = new string[1];
			temp [0] = "Content/";
			int i = 0;
			foreach (string s in str) {
				dir[i] = s.Split (temp, StringSplitOptions.RemoveEmptyEntries)[1].Split('.')[0];
				content.Add (dir [i]);
				i++;
			}
			return content;
		}

		public List<KeyBind> MenuKeyBindSetup(){
			List<KeyBind> keybinds = new List<KeyBind> ();

			KeyBind keybind1 = new KeyBind ();
			keybind1.EntityID = "global";
			keybind1.Keys.Add ("Up");
			keybind1.Action = "up";
			KeyBind keybind2 = new KeyBind ();
			keybind2.EntityID = "global";
			keybind2.Keys.Add ("Down");
			keybind2.Action = "down";
			KeyBind keybind3 = new KeyBind ();
			keybind3.EntityID = "global";
			keybind3.Keys.Add ("Enter");
			keybind3.Action = "enter";
			KeyBind keybind4 = new KeyBind ();
			keybind4.EntityID = "global";
			keybind4.Keys.Add ("Left");
			keybind4.Action = "left";
			KeyBind keybind5 = new KeyBind ();
			keybind5.EntityID = "global";
			keybind5.Keys.Add ("Right");
			keybind5.Action = "right";
			KeyBind keybind6 = new KeyBind ();
			keybind6.EntityID = "global";
			keybind6.Keys.Add ("Esc");
			keybind6.Action = "menu";
			keybinds.Add (keybind1);
			keybinds.Add (keybind2);
			keybinds.Add (keybind3);
			keybinds.Add (keybind4);
			keybinds.Add (keybind5);

			return keybinds;
		}

		//Keyboard Setup 1 
		public List<KeyBind> DefineKeybindingsSetup(string up, string down, string left, string right, string use, string playerName){
			List<KeyBind> keybinds = new List<KeyBind> ();
			KeyBind keybind1 = new KeyBind ();
			keybind1.Keys.Add (up.ToLower());
			keybind1.Keys.Add (up.ToUpper());
			keybind1.EntityID = playerName;
			keybind1.Action = "up";
			KeyBind keybind2 = new KeyBind ();
			keybind2.Keys.Add (left.ToLower());
			keybind2.Keys.Add (left.ToUpper());
			keybind2.EntityID = playerName;
			keybind2.Action = "left";
			KeyBind keybind3 = new KeyBind ();
			keybind3.Keys.Add (down.ToLower());
			keybind3.Keys.Add (down.ToUpper());
			keybind3.EntityID = playerName;
			keybind3.Action = "down";
			KeyBind keybind4 = new KeyBind ();
			keybind4.Keys.Add (right.ToLower());
			keybind4.Keys.Add (right.ToUpper());
			keybind4.EntityID = playerName;
			keybind4.Action = "right";
			KeyBind keybind5 = new KeyBind ();
			keybind5.Keys.Add (use.ToLower());
			keybind5.Keys.Add (use.ToUpper());
			keybind5.EntityID = playerName;
			keybind5.Action = "action";

			keybinds.Add(keybind1);
			keybinds.Add(keybind2);
			keybinds.Add(keybind3);
			keybinds.Add(keybind4);
			keybinds.Add(keybind5);

			return keybinds;
		}

		//Keyboard Setup 2
		public List<KeyBind> DefineKeybindingsSetup2(){
			List<KeyBind> keybinds = new List<KeyBind> ();
			KeyBind keybind1 = new KeyBind ();
			keybind1.Keys.Add ("i");
			keybind1.Keys.Add ("I");
			keybind1.EntityID = "player2";
			keybind1.Action = "up";
			KeyBind keybind2 = new KeyBind ();
			keybind2.Keys.Add ("j");
			keybind2.Keys.Add ("J");
			keybind2.EntityID = "player2";
			keybind2.Action = "left";
			KeyBind keybind3 = new KeyBind ();
			keybind3.Keys.Add ("k");
			keybind3.Keys.Add ("K");
			keybind3.EntityID = "player2";
			keybind3.Action = "down";
			KeyBind keybind4 = new KeyBind ();
			keybind4.Keys.Add ("l");
			keybind4.Keys.Add ("L");
			keybind4.EntityID = "player2";
			keybind4.Action = "right";
			KeyBind keybind5 = new KeyBind ();
			keybind5.Keys.Add ("Add");
			keybind5.EntityID = "player2";
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