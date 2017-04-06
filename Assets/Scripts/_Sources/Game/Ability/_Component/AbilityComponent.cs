using Entitas;

namespace Game
{
	[Card]
	public class AbilityComponent : IComponent
	{
		public string AbilityClassName;
		public Ability Ability;
	}
}

