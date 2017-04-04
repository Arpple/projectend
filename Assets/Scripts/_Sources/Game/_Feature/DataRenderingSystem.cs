using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class DataRenderingSystem : Feature
	{
		public DataRenderingSystem(Contexts contexts) : base("Data Rendering")
		{
			//deck card
			Add(new RenderPlayerDeckSystem(contexts));
			Add(new PlayerBoxCardSystem(contexts));
			
			//unit
			Add(new OnDeadAbilitySystem(contexts));
			Add(new DeadSystem(contexts));

			//map
			Add(new RenderMapPositionSystem(contexts));
			Add(new TileActionSystem(contexts));

			//event
			Add(new RoleOriginWinningSystem(contexts));
			Add(new WinSystem(contexts));
		}
	}

}
