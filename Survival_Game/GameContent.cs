using System;
using Game_Engine;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Survival_Game
{
	public class GameContent
	{
		Dictionary<string, List<string>> keyBindings;
		public GameContent ()
		{
			keyBindings = new Dictionary<string, List<string>> ();

		}

		public void DefineKeybindingPlayer1(){
			List<string> keybinding = new List<string> ();
			keybinding.Add ("W");
			keybinding.Add ("A");
			keybinding.Add ("S");
			keybinding.Add ("D");
			keybinding.Add ("F");
			keyBindings.Add ("player1", keybinding);
			keybinding.Clear ();
		}

		public void DefineKeybindingPlayer2(){
			List<string> keybinding = new List<string> ();
			keybinding.Add ("I");
			keybinding.Add ("J");
			keybinding.Add ("K");
			keybinding.Add ("L");
			keybinding.Add ("Add");
			keyBindings.Add ("player2", keybinding);
			keybinding.Clear ();
		}

		public void DefineKeybindingForGamePad(string player){
			List<string> keybinding = new List<string> ();
			GamePadState state = GamePad.GetState ();
			keybinding.Add ("Up");
			keybinding.Add ("Left");
			keybinding.Add ("Down");
			keybinding.Add ("Right");
			keybinding.Add ("X");
			keyBindings.Add (player, keybinding);
			keybinding.Clear ();
		}

		public void CreatePlayer(int numOfPlayers)
		{
			
		}
	}
}

