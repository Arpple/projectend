using Entitas;

namespace Game
{
	[Game, Tile, Card]
	public class ResourceComponent : IComponent
	{
		public string SpritePath;
		public string BasePrefabsPath;
	}
}

