using Entitas;

namespace End.Game
{
	[Game]
	public class AbilityComponent : IComponent
	{
		public string AbilityClassName;
		public Ability Ability;
	}
}

