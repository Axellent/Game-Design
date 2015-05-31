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
			//gameContent.Add ();
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

		public List<KeyBind<Keys>> MenuKeyBindSetup(){
			List<KeyBind<Keys>> keybinds = new List<KeyBind<Keys>> ();

			KeyBind<Keys> keybind1 = new KeyBind<Keys> ();
			keybind1.EntityID = "none";
			keybind1.Keys.Add (Keys.Up);
			keybind1.Action = "up";
			KeyBind<Keys> keybind2 = new KeyBind<Keys> ();
			keybind2.EntityID = "none";
			keybind2.Keys.Add (Keys.Down);
			keybind2.Action = "down";
			KeyBind<Keys> keybind3 = new KeyBind<Keys> ();
			keybind3.EntityID = "none";
			keybind3.Keys.Add (Keys.Enter);
			keybind3.Action = "enter";
			KeyBind<Keys> keybind4 = new KeyBind<Keys> ();
			keybind4.EntityID = "none";
			keybind4.Keys.Add (Keys.Left);
			keybind4.Action = "left";
			KeyBind<Keys> keybind5 = new KeyBind<Keys> ();
			keybind5.EntityID = "none";
			keybind5.Keys.Add (Keys.Right);
			keybind5.Action = "right";

			keybinds.Add (keybind1);
			keybinds.Add (keybind2);
			keybinds.Add (keybind3);
			keybinds.Add (keybind4);
			keybinds.Add (keybind5);

			return keybinds;
		}

		//Keyboard Setup 1 
		public List<KeyBind<Keys>> DefineKeybindingsSetup1(string playerID){
			List<KeyBind<Keys>> keybinds = new List<KeyBind<Keys>> ();
			KeyBind<Keys> keybind1 = new KeyBind<Keys> ();
			keybind1.Keys.Add (Keys.W);
			keybind1.EntityID = playerID;
			keybind1.Action = "up";
			KeyBind<Keys> keybind2 = new KeyBind<Keys> ();
			keybind2.Keys.Add (Keys.A);
			keybind2.EntityID = playerID;
			keybind2.Action = "left";
			KeyBind<Keys> keybind3 = new KeyBind<Keys> ();
			keybind3.Keys.Add (Keys.S);
			keybind3.EntityID = playerID;
			keybind3.Action = "down";
			KeyBind<Keys> keybind4 = new KeyBind<Keys> ();
			keybind4.Keys.Add (Keys.D);
			keybind4.EntityID = playerID;
			keybind4.Action = "right";
			KeyBind<Keys> keybind5 = new KeyBind<Keys> ();
			keybind5.Keys.Add (Keys.F);
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
		public List<KeyBind<Keys>> DefineKeybindingsSetup2(string playerID){
			List<KeyBind<Keys>> keybinds = new List<KeyBind<Keys>> ();
			KeyBind<Keys> keybind1 = new KeyBind<Keys> ();
			keybind1.Keys.Add (Keys.I);
			keybind1.EntityID = playerID;
			keybind1.Action = "up";
			KeyBind<Keys> keybind2 = new KeyBind<Keys> ();
			keybind2.Keys.Add (Keys.J);
			keybind2.EntityID = playerID;
			keybind2.Action = "left";
			KeyBind<Keys> keybind3 = new KeyBind<Keys> ();
			keybind3.Keys.Add (Keys.K);
			keybind3.EntityID = playerID;
			keybind3.Action = "down";
			KeyBind<Keys> keybind4 = new KeyBind<Keys> ();
			keybind4.Keys.Add (Keys.L);
			keybind4.EntityID = playerID;
			keybind4.Action = "right";
			KeyBind<Keys> keybind5 = new KeyBind<Keys> ();
			keybind5.Keys.Add (Keys.Add);
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
		public List<KeyBind<Buttons>> DefineKeybindingsForGamePad(string playerID){
			List<KeyBind<Buttons>> keybinds = new List<KeyBind<Buttons>> ();
			KeyBind<Buttons> keybind1 = new KeyBind<Buttons> ();
			keybind1.Keys.Add (Buttons.DPadUp);
			keybind1.EntityID = playerID;
			keybind1.Action = "up";
			keybind1.IsController = true;
			KeyBind<Buttons> keybind2 = new KeyBind<Buttons> ();
			keybind2.Keys.Add (Buttons.DPadLeft);
			keybind2.EntityID = playerID;
			keybind2.Action = "left";
			keybind2.IsController = true;
			KeyBind<Buttons> keybind3 = new KeyBind<Buttons> ();
			keybind3.Keys.Add (Buttons.DPadDown);
			keybind3.EntityID = playerID;
			keybind3.Action = "down";
			keybind3.IsController = true;
			KeyBind<Buttons> keybind4 = new KeyBind<Buttons> ();
			keybind4.Keys.Add (Buttons.DPadRight);
			keybind4.EntityID = playerID;
			keybind4.Action = "right";
			keybind4.IsController = true;
			KeyBind<Buttons> keybind5 = new KeyBind<Buttons> ();
			keybind5.Keys.Add (Buttons.X);
			keybind5.EntityID = playerID;
			keybind5.Action = "action";
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