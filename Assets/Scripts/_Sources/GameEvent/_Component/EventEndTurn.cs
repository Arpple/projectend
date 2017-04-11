[GameEvent]
public class EventEndTurn : GameEventComponent
{
	public static bool TryEndTurn()
	{
		if(Contexts.sharedInstance.game.IsLocalPlayerTurn)
		{
			GameEvent.CreateEvent<EventEndTurn>();
			return true;
		}
		return false;
	}
}
