using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
	[Game, Unique]
	public class TurnComponent : IComponent
	{
		public int Count;
	}
}
