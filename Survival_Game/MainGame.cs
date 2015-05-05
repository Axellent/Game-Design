using System;
using Game_Engine;

namespace Survival_Game{

	public class MainGame{
		
		public MainGame(){
			
			GameEngine engine = new GameEngine();
			engine.Run();
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}