using Entitas;
using Game.UI;

namespace Game
{
	public class DataRenderingSystems : Feature
	{
		public DataRenderingSystems(Contexts contexts) : base("Data Rendering")
		{
			//deck card
			Add(new PlayerDeckRenderingSystem(contexts));
			Add(new BoxCardRenderingSystem(contexts));
			
			//unit
			Add(new OnDeadAbilitySystem(contexts));
			Add(new DeadSystem(contexts));
			Add(new LocalCharacterFlagSystem(contexts));

			//map
			Add(new UnitPositionRenderingSystem(contexts));
			Add(new TilePositionRenderingSystem(contexts));
			Add(new TileActionSystem(contexts));

			//event
			Add(new RoleOriginWinningSystem(contexts));
			Add(new WinSystem(contexts));
			Add(new PlayingFlagSystem(contexts));
		}
	}

}
