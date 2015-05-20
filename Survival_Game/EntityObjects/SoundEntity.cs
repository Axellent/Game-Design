using System;

using Microsoft.Xna.Framework.Audio;

namespace Survival_Game
{
	public abstract class SoundEntity
	{
		private float volume;
		private int duration;
		private SoundEffect soundEffect;

		public SoundEffect SoundEffect {
			get {
				return soundEffect;
			}
			set {
				soundEffect = value;
			}
		}

		internal float Volume {
			get {
				return volume;
			}
			set {
				volume = value;
			}
		}

		public int Duration {
			get{
				return duration;
			}
			set {
				duration = value;
			}
		}
	}
}

