using Entitas;

namespace Game
{
	[Game, Tile]
	public class ResourceComponent : IComponent
	{
		public string SpritePath;
		public string BasePrefabsPath;
	}
}

