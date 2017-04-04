using Entitas;

namespace Game
{
	[Game]
	public class CardComponent : IComponent
	{
		public short Id;
		public Card Type;
	}
}