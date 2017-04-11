using Entitas;
using Entitas.CodeGeneration.Attributes;


namespace MapEditor
{
	public enum BrushAction
	{
		Tile,
		Spawnpoint,
	}

	[Tile, Unique]
	public class TileBrushComponent : IComponent
	{
		public Tile TileType;
		public BrushAction Action;
		public int SpawnpointIndex;
	}

}
