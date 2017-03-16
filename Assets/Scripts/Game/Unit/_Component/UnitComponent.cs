using Entitas;
using End.Network;

namespace End.Game
{
	[Game]
	public class UnitComponent : IComponent
	{
		public Player OwnerPlayer;
	}
}
