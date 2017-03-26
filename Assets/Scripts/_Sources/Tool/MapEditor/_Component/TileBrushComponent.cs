using Entitas;
using Entitas.CodeGenerator.Api;
using End.Game;

namespace End.MapEditor
{
	public enum BrushAction
	{
		Tile,
		Spawnpoint,
	}

	[Game, Unique]
	public class TileBrushComponent : IComponent
	{
		public Tile TileType;
		public BrushAction Action;
		public int SpawnpointIndex;
	}

}
