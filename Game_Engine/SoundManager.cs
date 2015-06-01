using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game_Engine{

	//author: Rasmus Bäckerhall
	public class SoundManager{

		private float masterVolume = 1.0F;

		public float MasterVolume {
			get {
				return masterVolume;
			}
			set {
				masterVolume = value;
			}
		}

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

		public void playSoundEffect(Entity entity, Entity actor){
			
		}

		public void deleteEntitySoundEffect(Entity entity){
		
		}

		public void stopBackgroundSound(SoundEffect effect){
			SoundEffectInstance effectInstance = effect.CreateInstance ();
			effectInstance.Stop ();
		}

		public void pauseBackgroundSound(SoundEffect effect){
			SoundEffectInstance effectInstance = effect.CreateInstance ();
			effectInstance.Pause ();
		}

		public void playBackgroundSound(SoundEffect effect, bool isLooped){
			try{
				SoundEffectInstance effectInstance = effect.CreateInstance ();
				effectInstance.IsLooped = isLooped;
				effectInstance.Volume = masterVolume;
				effectInstance.Play ();
			}catch(NoAudioHardwareException e){
				Console.WriteLine (e);
			}
		}

		public void playSound(){
			
		}
	}
}

