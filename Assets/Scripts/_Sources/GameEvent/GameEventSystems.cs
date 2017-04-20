public class GameEventSystems : Feature
{
	public GameEventSystems(Contexts contexts) : base("Event Systems")
	{
		Add(new EventEndTurnSystem(contexts));
		Add(new EventMoveCardSystem(contexts));
		Add(new EventUseCardOnTileSystem(contexts));
		Add(new EventUseCardOnUnitSystem(contexts));
		Add(new EventHpDepleteSystem(contexts));
		Add(new EventGameEndSystem(contexts));
	}
}