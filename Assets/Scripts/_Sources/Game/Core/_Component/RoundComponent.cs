using Entitas;
using Entitas.CodeGenerator.Api;

namespace Game
{
	[Game, Unique]
	public class RoundComponent : IComponent
	{
		public int Count;
	}
}
