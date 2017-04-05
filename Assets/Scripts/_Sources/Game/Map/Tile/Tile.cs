using Entitas;
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
		public static GameEntity GetUnitOnTile(this TileEntity tile)
		{
			return Contexts.sharedInstance.game.GetEntities(GameMatcher.GameUnit)
				.Where(obj => obj.gameMapPosition.Equals(tile.gameMapPosition))
				.FirstOrDefault();
		}

		public static TileEntity GetTileOfUnit(this GameEntity unit)
		{
			return Contexts.sharedInstance.tile.GetEntities()
				.Where(t => t.gameMapPosition.Equals(unit.gameMapPosition))
				.First();
		}
	}
}

