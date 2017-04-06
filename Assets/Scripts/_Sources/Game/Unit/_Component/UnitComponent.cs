using Entitas;

namespace Game
{
	[Unit]
	public class UnitComponent : IComponent
	{
		public int Id;
		public GameEntity OwnerEntity;
	}
}
