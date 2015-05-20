using System;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game_Engine{

	//author: Rasmus Bäckerhall
	public class SoundManager{

		private float MasterVolume;		
		private float backgroundVolume;
		private float miscVolume;


		public SoundManager(){
		}

		public List<SoundEffect> LoadContent(ContentManager Content, List<string> audioFiles){
			List<SoundEffect> content = new List<SoundEffect> ();

			foreach (string audioFile in audioFiles) {
				content.Add(Content.Load<SoundEffect> (audioFile));
			}
			return content;
		}

		public void createSoundEffectInstance(Entity entity, SoundEffect effect){
		
		}

		public void playSoundEffect(Entity entity){
		
		}

		public void deleteEntitySoundInstance(Entity entity){
		
		}

		public void stopBackgroundSound(SoundEffectInstance effectInstance){
			effectInstance.Stop ();
		}

		public void pauseBackgroundSound(SoundEffectInstance effectInstance){
			effectInstance.Pause ();
		}

		public void playBackgroundSound(SoundEffectInstance effectInstance){
			effectInstance.IsLooped = true;
			effectInstance.Volume = MasterVolume * backgroundVolume;
			effectInstance.Play ();
		}

		public void playSound(){
			
		}
	}
}

