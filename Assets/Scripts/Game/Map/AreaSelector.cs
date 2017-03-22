using Entitas;
using System.Linq;

namespace End.Game
{
	public static class AreaSelector
	{
		public static GameEntity[] GetAllInRange(GameEntity center, int range, bool includeCenter = false)
		{
			var tiles = Contexts.sharedInstance.game.GetEntities(GameMatcher.Tile)
				.Where(t => t.mapPosition.GetDistance(center.mapPosition) <= range);

			return includeCenter ? tiles.ToArray() : tiles.Where(t => t != center).ToArray();
		}
	}

}
