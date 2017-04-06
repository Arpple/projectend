using Entitas;

namespace Game
{
	[Game, Tile, Card, Unit]
	public class ResourceComponent : IComponent
	{
		public string SpritePath;
		public string BasePrefabsPath;
	}
}

