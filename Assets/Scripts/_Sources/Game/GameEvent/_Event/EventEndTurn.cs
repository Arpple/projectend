using Entitas;
using UnityEngine;

namespace End.Game
{
	[GameEvent]
	public class EventEndTurn : GameEventComponent, IRemoteEvent
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
			var playingOrder = _contexts.game.playingOrder;
			playingOrder.NextPlayerId();
			Debug.Log(playingOrder);
		}
	}

}
