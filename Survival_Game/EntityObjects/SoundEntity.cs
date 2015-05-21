using System;

using Microsoft.Xna.Framework.Audio;

namespace Survival_Game
{
	public class SoundEntity
	{
		private float volume;
		private float duration;
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

		public float Duration {
			get{
				return duration;
			}
			set {
				duration = value;
			}
		}

		public SoundEntity(float volume, float duration){
			this.volume = volume;
			this.duration = duration;
		}
	}
}

