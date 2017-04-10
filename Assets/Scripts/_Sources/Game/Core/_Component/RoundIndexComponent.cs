using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
	[Game, Unique]
	public class RoundIndexComponent : IComponent
	{
		public int Index;
	}
}
