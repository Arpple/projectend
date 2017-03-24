using Entitas;

namespace End.Game
{
	public class MapSystem : Feature
	{
		public MapSystem(Contexts contexts, MapSetting setting) : base("Map System")
		{
			Add(new CreateMapTileSystem(contexts, setting.GameMap.Load(), setting));
			Add(new CreateTileGraphSystem(contexts));
			Add(new CreateTileActionSystem(contexts));
		}
	}
}
