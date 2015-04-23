using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class PhysicsManager{
		private List<SceneObject> sceneObjects;

		public List<SceneObject> SceneObjects{
			get{
				return sceneObjects;
			}
			set{
				sceneObjects = value;
			}
		}

		public PhysicsManager(){

		}

		public void UpdatePhysics(Vector2 worldPos, Vector2 oldWorldPos, List<SceneObject> sceneObjects){
			for(int i = 0; i < sceneObjects.Count; i++){
				sceneObjects[i].X += oldWorldPos.X - worldPos.X;
				sceneObjects[i].Y += oldWorldPos.Y - worldPos.Y;
			}
			this.sceneObjects = sceneObjects;
		}
	}
}

