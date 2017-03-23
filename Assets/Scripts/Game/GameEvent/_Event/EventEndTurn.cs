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

	public class EventEndTurnSystem : GameEventSystem
	{
		public EventEndTurnSystem(Contexts contexts) : base(contexts) { }

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventEndTurn, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.isEventEndTurn;
		}

		protected override void Process(GameEventEntity entity)
		{
			_contexts.game.playingOrder.NextPlayerId();
		}
	}

}
