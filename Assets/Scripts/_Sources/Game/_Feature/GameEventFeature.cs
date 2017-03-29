using Entitas;

namespace End.Game
{
	public class GameEventFeature : Feature
	{
		public GameEventFeature(Contexts contexts) : base("Game Event")
		{
			Add(new EventMoveUnitSystem(contexts));
			Add(new EventEndTurnSystem(contexts));
			Add(new EventMoveCardSystem(contexts));
			Add(new EventDamageSystem(contexts));
		}
	}
}

