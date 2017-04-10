using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
	[Game, Unique]
	public class RoundComponent : IComponent
	{
		public int Count;
	}
}
