using System;

namespace Game_Engine{
	
	public abstract class EngineObject{
		private float x;
		private float y;
		private float width;
		private float height;

		public float X{
			get{
				return x;
			}
			set{
				x = value;
			}
		}

		public float Y{
			get{
				return y;
			}
			set{
				y = value;
			}
		}

		public float Width{
			get{
				return width;
			}
			set{
				width = value;
			}
		}

		public float Height{
			get{
				return height;
			}
			set{
				height = value;
			}
		}
	}
}

