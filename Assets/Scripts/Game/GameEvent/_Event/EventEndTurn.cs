using Entitas;

namespace End.Game
{
	[GameEvent]
	public class EventEndTurn : GameEventComponent
	{
		public static void Create()
		{
			GameEvent.CreateEvent<EventEndTurn>();
		}
	}

}
