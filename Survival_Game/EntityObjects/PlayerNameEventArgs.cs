using System;

namespace Survival_Game
{
	public class PlayerNameEventArgs : EventArgs
	{
		private string playerName;
		private bool isController;

		public string PlayerName {
			get {
				return playerName;
			}
			set {
				playerName = value;
			}
		}

		public bool IsController {
			get {
				return isController;
			}
			set {
				isController = value;
			}
		}

		public PlayerNameEventArgs (string playerName, bool isController)
		{
			this.playerName = playerName;
			this.isController = isController;
		}
	}
}

