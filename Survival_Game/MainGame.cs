using System;
using Game_Engine;

namespace Survival_Game{

	public class MainGame{
		
		private GameEngine engine;

		public MainGame(){
			
			ObjectObserver observer = new ObjectObserver ();
			engine = new GameEngine(observer);
			engine.Run();
		}

		public void LoadContent()
		{
			
		}

		public void Update()
		{

		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}