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
		List<Entity> randomEntities = new List<Entity>();

		static int tileNO = 1;
		static int berryBushNO = 1;
		static int wolfNO = 1;

		public const int PORTION_WIDTH = 2000;
		public const int PORTION_HEIGHT = 2000;
		public const int TILE_WIDTH = 50;
		public const int TILE_HEIGHT = 50;
		public const int BUSH_WIDTH = 50;
		public const int BUSH_HEIGHT = 40;
		public const int WOLF_WIDTH = 100;
		public const int WOLF_HEIGHT = 150;

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
					curTileBox = new BoundingBox(new Vector3(curX, curY, 0),
						new Vector3(curX + TILE_WIDTH, curY + TILE_HEIGHT, 0));
					curTile = new Tile("tile" + tileNO, curX, curY, TILE_WIDTH, TILE_HEIGHT,
						0, curTileBox, 0, null, false);
					tiles.Add(curTile);
					entities.Add(curTile);

					tileNO++;
					curX += TILE_WIDTH;
				}
				curX = bounds.Min.X;
				curY += TILE_HEIGHT;
			}
		}

		public void GenerateBerryBushes(List<Entity> entities){
			Random rand = new Random();
			int nEntities = rand.Next(0, 20);

			for(int i = 0; i < nEntities; i++) {
				float randX = rand.Next((int)bounds.Min.X, (int)bounds.Max.X);
				float randY = rand.Next((int)bounds.Min.Y, (int)bounds.Max.Y);
			
				BoundingBox bushBounds = new BoundingBox(new Vector3(randX, randY, 0),
					new Vector3(randX + BUSH_WIDTH, randY + BUSH_HEIGHT, 0));

				Bush berryBush = new Bush("bush" + berryBushNO, randX, randY, BUSH_WIDTH, BUSH_HEIGHT, 0, bushBounds, 1, null);

				if(!PhysicsManager.CheckEntityCollision(berryBush, entities)){
					randomEntities.Add(berryBush);
					entities.Add(berryBush);
					berryBushNO++;
				}
			}
		}

		/* Generates new creatures into the game. */
		public void GenerateBeasts(List<Entity> entities){
			Random rand = new Random();
			int nEntities = rand.Next(10, 20);

			for(int i = 0; i < nEntities; i++) {
				float randX = rand.Next((int)bounds.Min.X, (int)bounds.Max.X);
				float randY = rand.Next((int)bounds.Min.Y, (int)bounds.Max.Y);

				BoundingBox wolfBounds = new BoundingBox(new Vector3(randX, randY, 0),
					new Vector3(randX + WOLF_WIDTH, randY + WOLF_HEIGHT, 0));

				Wolf wolf = new Wolf("wolf" + wolfNO, randX, randY, WOLF_WIDTH, WOLF_HEIGHT, 0, wolfBounds, 1, null, false);

				if(!PhysicsManager.CheckEntityCollision(wolf, entities)) {
					randomEntities.Add(wolf);
					entities.Add(wolf);
					wolfNO++;
				}
			}
		}

		/* Generates entities in the portion and adds the portion to the list of already generated portions. */
		public void AddPortion(List<Portion> generatedPortions, List<Entity> entities){
			GenerateTiles(entities);
			GenerateBerryBushes(entities);
			GenerateBeasts(entities);
			generatedPortions.Add(this);
		}

		/* Removes all entities in the portion from the engine entities and deletes the portion from the
		already generated list. */
		public void RemPortion(List<Portion> generatedPortions, List<Entity> entities){
			for(int i = 0; i < randomEntities.Count; i++){
				entities.Remove(randomEntities[i]);
			}
			for(int i = 0; i < tiles.Count; i++){
				entities.Remove(tiles[i]);
			}
			generatedPortions.Remove(this);
		}
	}
}

