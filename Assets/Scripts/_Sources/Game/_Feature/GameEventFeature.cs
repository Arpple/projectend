using Entitas;
using Game.Offline;

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

			if(GameController.Instance.IsOffline)
			{
				Add(new LocalFlagPassingSystem(contexts));
			}
		}
	}
}

