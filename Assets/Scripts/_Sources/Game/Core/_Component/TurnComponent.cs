using Entitas;
using Entitas.CodeGenerator.Api;

namespace Game
{
	[Game, Unique]
	public class TurnComponent : IComponent
	{
		public int Count;
	}
}
