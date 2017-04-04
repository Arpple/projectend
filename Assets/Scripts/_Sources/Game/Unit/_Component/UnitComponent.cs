using Entitas;

namespace Game
{
	[Game]
	public class UnitComponent : IComponent
	{
		public int Id;
		public GameEntity OwnerEntity;
	}
}
