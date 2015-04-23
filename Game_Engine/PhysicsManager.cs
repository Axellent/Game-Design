using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class PhysicsManager{

		public PhysicsManager(){

		}

		public void UpdatePhysics(Vector2 worldPos, List<SceneObject> sceneObjects){
			for(int i = 0; i < sceneObjects.Count; i++){
				sceneObjects[i].Width += worldPos.X;
				sceneObjects[i].Height += worldPos.Y;
			}
		}
	}
}

