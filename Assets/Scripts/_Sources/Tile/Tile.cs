using Entitas;
using System.Linq;

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
	//TownField,
}

public static class TileExtension
{
	public static UnitEntity GetUnitOnTile(this TileEntity tile)
	{
		return Contexts.sharedInstance.unit.GetEntitiesWithMapPosition(tile.mapPosition.Value)
			.FirstOrDefault();
	}

	public static TileEntity GetTileOfUnit(this UnitEntity unit)
	{
		return Contexts.sharedInstance.tile.GetEntitiesWithMapPosition(unit.mapPosition.Value)
			.First();
	}
}
