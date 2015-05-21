﻿using System;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game_Engine{

	//author: Rasmus Bäckerhall
	public class SoundManager{

		private float MasterVolume = 1.0F;		
		private float backgroundVolume = 1.0F;
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
			SoundEffectInstance effectInstance = effect.CreateInstance ();
			effectInstance.IsLooped = isLooped;
			effectInstance.Volume = MasterVolume * backgroundVolume;
			effectInstance.Play ();
		}

		public void playSound(){
			
		}
	}
}

