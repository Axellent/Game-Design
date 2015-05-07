using System;
using Game_Engine;

namespace Survival_Game{

	public class MainGame{
		
		private GameEngine engine;

		public MainGame(){
			
			ObjectObserver observer = new ObjectObserver ();
			engine = new GameEngine();
			IDisposable dis = engine.Subscribe (observer);
			observer.AddDisposableOBserver(dis);
			engine.Run();
		}

		public void LoadContent(GameEngine engine)
		{
			MenuController menuController = new MenuController (new StartMenu(), new OptionMenu(), new PlayGameMenu());
		}

		public static void Main(){
			MainGame game = new MainGame();
		}
	}
}