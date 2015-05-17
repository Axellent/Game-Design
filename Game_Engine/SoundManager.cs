using System;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game_Engine{

	//author: Rasmus Bäckerhall
	public class SoundManager{

		private float volume = 2.0F;

		public float Volume {
			get {
				return volume;
			}
			set {
				volume = value;
			}
		}

		public SoundManager(){
		}

		public List<SoundEffectInstance> LoadContent(ContentManager Content, List<string> audioFiles){
			List<SoundEffectInstance> content = new List<SoundEffectInstance> ();

			foreach (string audioFile in audioFiles) {
				content.Add(Content.Load<SoundEffect> (audioFile).CreateInstance());
			}
			return content;
		}

		public SoundEffectInstance createSoundEffectInstance(){

		}

		public void deleteSoundEffectInstance(SoundEffectInstance effectInstance){
			effectInstance.Dispose ();
		}

		public void stopBackgroundSound(SoundEffectInstance effectInstance){
			effectInstance.Stop ();
		}

		public void pauseBackgroundSound(SoundEffectInstance effectInstance){
			effectInstance.Pause ();
		}

		public void playBackgroundSound(SoundEffectInstance effectInstance){
			effectInstance.
			effectInstance.IsLooped = true;
			effectInstance.Volume = volume;
			effectInstance.Play ();
		}

		public void playSound(){
			
		}
	}
}

