using Entitas;

namespace End.Game
{
	[Game]
	public class UnitComponent : IComponent
	{
		public int Id;
		public Player OwnerPlayer;
	}
}
