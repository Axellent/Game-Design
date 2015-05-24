using System;
using Game_Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Survival_Game{

	/* Author: Axel Sigl
	 * A section of the game terrain containing all the tiles in that area.*/
	public class Portion{
		BoundingBox bounds;
		List<Tile> tiles = new List<Tile>();

		int tileNO = 1;

		public const int PORTION_WIDTH = 2000;
		public const int PORTION_HEIGHT = 2000;
		public const int TILE_WIDTH = 50;
		public const int TILE_HEIGHT = 50;

		public BoundingBox Bounds{
			get{
				return bounds;
			}
			set{
				bounds = value;
			}
		}

		public List<Tile> Tiles{
			get{
				return tiles;
			}
			set{
				tiles = value;
			}
		}

		public Portion(BoundingBox bounds){
			this.bounds = bounds;
		}


		/* Generates terrain in a certain portion of the world. */
		public void GenerateTiles(List<Entity> entities){
			Tile curTile;
			BoundingBox curTileBox;
			float curX = bounds.Min.X;
			float curY = bounds.Min.Y;

			while(curY <= bounds.Max.Y){
				while(curX <= bounds.Max.X) {
					curTileBox = new BoundingBox();
					curTile = new Tile("tile" + tileNO, curX, curY, TILE_WIDTH, TILE_HEIGHT,
						0, curTileBox, 0, null, false);
					entities.Add(curTile);
					tiles.Add(curTile);

					tileNO++;
					curX += TILE_WIDTH;
				}
				curX = 0;
				curY += TILE_HEIGHT;
			}
		}

		//Generates entities in the portion and adds the portion to the list of already generated portions.
		public void AddPortion(List<Portion> generatedPortions, List<Entity> entities){
			//TODO: Generate all possible entities.
			GenerateTiles(entities);
			generatedPortions.Add(this);
		}

		//Removes all entities in the portion from the engine entities and deletes the portion from the
		//already generated list.
		public void RemPortion(List<Portion> generatedPortions, List<Entity> entities){
			//TODO: Remove all entities from portion.
			for(int i = 0; i < tiles.Count; i++){
				entities.Remove(tiles[i]);
			}
			generatedPortions.Remove(this);
		}
	}
}

