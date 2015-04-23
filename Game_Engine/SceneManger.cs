using System;
using System.Collections.Generic;

namespace Game_Engine{

	public class SceneManger{
		private List<SceneObject> sceneObjects;

		public List<SceneObject> SceneObjects{
			get{
				return sceneObjects;
			}
			set{
				sceneObjects = value;
			}
		}

		public SceneManger(){
			sceneObjects = new List<SceneObject>();
		}

		public void AddSceneObject(SceneObject sceneObject){
			sceneObjects.Add(sceneObject);
		}
	}
}

