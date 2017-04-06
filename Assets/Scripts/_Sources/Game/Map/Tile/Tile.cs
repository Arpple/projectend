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
		public static UnitEntity GetUnitOnTile(this TileEntity tile)
		{
			return Contexts.sharedInstance.unit.GetEntitiesWithGameMapPosition(tile.gameMapPosition.Value)
				.FirstOrDefault();
		}

		public static TileEntity GetTileOfUnit(this UnitEntity unit)
		{
			return Contexts.sharedInstance.tile.GetEntitiesWithGameMapPosition(unit.gameMapPosition.Value)
				.First();
		}
	}
}

