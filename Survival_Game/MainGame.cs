using System;
using Game_Engine;

namespace Survival_Game{

	public class MainGame{
		
		private GameEngine engine;

		public MainGame(){
			
			ObjectObserver observer = new ObjectObserver ();
			engine = new GameEngine();
			IDisposable dis = engine.SubscribeObserver (observer);
			observer.AddDisposableOBserver(dis);
			engine.Run();
		}

		public void LoadContent()
		{
			
			MenuController menuController = MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());
		}

		public void Update()
		{

		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}