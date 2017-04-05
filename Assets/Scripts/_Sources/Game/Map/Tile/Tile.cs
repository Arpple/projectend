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
			return Contexts.sharedInstance.game.GetEntitiesWithGameMapPosition(tile.gameMapPosition.Value)
				.FirstOrDefault();
		}

		public static TileEntity GetTileOfUnit(this GameEntity unit)
		{
			return Contexts.sharedInstance.tile.GetEntitiesWithGameMapPosition(unit.gameMapPosition.Value)
				.First();
		}
	}
}

