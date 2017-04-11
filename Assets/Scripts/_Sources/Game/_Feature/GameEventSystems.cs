public class EventSystems : Feature
{
	public EventSystems(Contexts contexts) : base("Game Event")
	{
		Add(new EventUseCardOnUnitSystem(contexts));
		Add(new EventUseCardOnTileSystem(contexts));
		Add(new EventEndTurnSystem(contexts));
		Add(new EventMoveCardSystem(contexts));
	}
}
