using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Game_Engine{

	//author: Martin Jakobsson
	/* Governs which entities are currently active and sorts them in order
	 * to make the RenderManagers life easier. */
	public class SceneManger{
		List<Entity> savedEntities;

		public SceneManger(){
			savedEntities = new List<Entity>();
		}

		/* Filters out non-renderable entities and returns the rest,
		 * sorted by layer. */
		public List<RenderedEntity> SortRenderedEntities(List<Entity> entities){
			List<RenderedEntity> renderedEntities = new List<RenderedEntity>(entities.Count);

			foreach(Entity entity in entities){
				var entityType = entity.GetType();

				if(entityType == typeof(RenderedEntity)
					|| entityType.IsSubclassOf(typeof(RenderedEntity))){
					renderedEntities.Add((RenderedEntity)entity);
				}
			}
			List<RenderedEntity> sorted = renderedEntities.OrderBy(o=>o.Layer).ToList();

			return sorted;
		}

		/* Adds entities priviously outside the limitbox back into the active entities list. */
		public List<Entity> RestoreSavedEntities(List<Entity> entities, BoundingBox limitbox){
			entities.AddRange (savedEntities.FindAll (e => limitbox.Intersects (e.HitBox)));
			savedEntities.RemoveAll (e => limitbox.Intersects (e.HitBox));
			for(int i = savedEntities.Count - 1; i >= 0; i--){
				if(limitbox.Intersects(savedEntities[i].HitBox)){
					entities.Add(savedEntities[i]);
					savedEntities.RemoveAt(i);
				}
			}
			//entities.AddRange (savedEntities.FindAll (e => limitbox.Intersects (e.HitBox)));
			//savedEntities.RemoveAll (e => limitbox.Intersects (e.HitBox));
			return entities;
		}

	
		/* Stores away the entities outside the defined limits for improved performance. */
		public List<Entity> RemoveFarawayEntities(List<Entity> entities, BoundingBox limitbox){
			savedEntities.AddRange (entities.FindAll (e => !limitbox.Intersects (e.HitBox)));
			entities.RemoveAll (e => !limitbox.Intersects (e.HitBox));
			for(int i = entities.Count - 1; i >= 0; i--){
				if(!limitbox.Intersects(entities[i].HitBox)){
					savedEntities.Add(entities[i]);
					entities.RemoveAt(i);
				}
			}
			//savedEntities.AddRange (entities.FindAll (e => !limitbox.Intersects (e.HitBox)));
			//entities.RemoveAll (e => !limitbox.Intersects (e.HitBox));
			return entities;
		}
	}
}
