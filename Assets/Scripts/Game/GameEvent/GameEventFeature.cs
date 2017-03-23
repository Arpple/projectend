using Entitas;

namespace End.Game
{
	public class GameEventFeature : Feature
	{
		public GameEventFeature(Contexts contexts) : base("Game Event")
		{
			Add(new EventMoveSystem(contexts));
			Add(new EventEndTurnSystem(contexts));
		}
	}
}

