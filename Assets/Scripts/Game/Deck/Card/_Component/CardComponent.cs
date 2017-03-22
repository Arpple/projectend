using Entitas;

namespace End.Game
{
	[Game]
	public class CardComponent : IComponent
	{
		public short Id;
		public Card Type;
	}
}