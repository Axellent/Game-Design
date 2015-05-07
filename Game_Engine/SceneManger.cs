﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	public class SceneManger{
		List<Entity> savedEntities;

		public SceneManger(){
			savedEntities = new List<Entity>();
		}

		public List<AnimatedEntity> SortAnimatedEntities(List<Entity> entities){
			List<AnimatedEntity> animatedEntities = new List<AnimatedEntity>(entities.Count);

			foreach(Entity entity in entities){
				var entityType = entity.GetType();
				if(entityType == typeof(AnimatedEntity)
					|| entityType == typeof(ActorEntity)
					|| entityType == typeof(StaticEntity)){
					animatedEntities.Add((AnimatedEntity)entity);
				}
			}
			List<AnimatedEntity> sorted = animatedEntities.OrderBy(o=>o.Layer).ToList();

			return sorted;
		}

		public List<Entity> AddSavedEntities(List<Entity> entities, BoundingBox limitbox){
			foreach(Entity savedEntity in savedEntities) {
				//TODO: add savedEntity to entities if it is inside the limitbox.
			}
			return entities;
		}

		public List<Entity> RemoveFarawayEntities(List<Entity> entities, BoundingBox limitbox){
			// TODO: Remove entities outside the limitbox and add them to savedEntities.
			return entities;
		}
	}
}

