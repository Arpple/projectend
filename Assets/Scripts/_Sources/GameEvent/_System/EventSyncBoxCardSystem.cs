using Entitas;

public class EventSyncBoxCardSystem : EventSystem
{
	public EventSyncBoxCardSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventSyncBoxCard);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventSyncBoxCard;
	}

	protected override void Process(GameEventEntity entity)
	{
		var e = entity.eventSyncBoxCard;

		e.Card.ReplaceInBox(e.BoxIndex);
	}
}