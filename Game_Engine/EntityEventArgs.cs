using System;

namespace Game_Engine
{
	public class EntityEventArgs : EventArgs{
		private Entity sender, entity;

		public Entity Sender {
			get {
				return sender;
			}
		}

		public Entity Entity {
			get {
				return entity;
			}
		}

		public EntityEventArgs(Entity sender, Entity entity){
			this.sender = sender;
			this.entity = entity;
		}
	}
}

