using Entitas;
using System.Linq;

namespace End.Game
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
			return context.GetEntities(GameMatcher.Unit)
				.Where(obj => obj.mapPosition.IsEqual(tile.mapPosition))
				.FirstOrDefault();
		}
	}
}

