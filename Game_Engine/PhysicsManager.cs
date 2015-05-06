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

		public void UpdatePhysics(Vector2 worldPos, Vector2 oldWorldPos, List<SceneObject> sceneObjects, float playerRotation){
			for(int i = 0; i < sceneObjects.Count; i++){
				if (!sceneObjects[i].Texture.Name.Equals ("player_s")) {
					sceneObjects[i].X += oldWorldPos.X - worldPos.X;
					sceneObjects[i].Y += oldWorldPos.Y - worldPos.Y;
				} else {
					sceneObjects[i].Rotation = playerRotation;
				}
			}
			this.sceneObjects = sceneObjects;
		}

		public void CollisionDetection(){
			
		}
	}
}

