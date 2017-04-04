using Entitas;

namespace Game
{
	public class GameEventFeature : Feature
	{
		public GameEventFeature(Contexts contexts) : base("Game Event")
		{
			Add(new EventUseCardOnUnitSystem(contexts));
			Add(new EventUseCardOnTileSystem(contexts));
			Add(new EventEndTurnSystem(contexts));
			Add(new EventMoveCardSystem(contexts));
		}
	}
}

