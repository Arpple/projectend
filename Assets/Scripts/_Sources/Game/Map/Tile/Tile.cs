﻿using Entitas;
using System.Linq;

namespace Game
{
	public enum Tile
	{
		None,
		Grass,
		DeepForest,
		Water,
        Desert,
        Mountain,
        Snow,
        SnowMountain,
        Space,
        TownField,
	}

	public static class TileExtension
	{
		public static GameEntity GetUnitOnTile(this GameEntity tile)
		{
			var context = Contexts.sharedInstance.game;
			return context.GetEntities(GameMatcher.GameUnit)
				.Where(obj => obj.gameMapPosition.Equals(tile.gameMapPosition))
				.FirstOrDefault();
		}
	}
}

