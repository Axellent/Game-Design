using System;
using Game_Engine;

namespace Survival_Game{
	
	public class MainGame{
		
		public MainGame(){
			RenderManager renderer = new RenderManager();
			Console.WriteLine("Hello World!");
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}

