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
			Add(new PlayerBoxCardAddSystem(contexts));
			
			//unit
			Add(new OnDeadBoxSystem(contexts));
			Add(new DeadSystem(contexts));

			//map
			Add(new RenderMapPositionSystem(contexts));

			//event
			Add(new RoleOriginWinningSystem(contexts));
			Add(new WinSystem(contexts));
		}
	}

}
