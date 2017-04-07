using Entitas;
using Entitas.CodeGenerator.Api;

namespace Game
{
	[Game, Unique]
	public class RoundIndexComponent : IComponent
	{
		public int Index;
	}
}
