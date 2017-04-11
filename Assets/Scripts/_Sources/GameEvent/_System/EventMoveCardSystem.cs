using Entitas;

public class EventMoveCardSystem : EventSystem
{
	public EventMoveCardSystem(Contexts contexts) : base(contexts) { }

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventMoveCard, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventMoveCard;
	}

	protected override void Process(GameEventEntity entity)
	{
		var e = entity.eventMoveCard;

		if (e.TargetPlayerEntity != null)
		{
			e.CardEntity.ReplaceOwner(e.TargetPlayerEntity);
		}
		else
		{
			e.CardEntity.RemoveOwner();
		}

		if (e.IsInBox)
		{
			e.CardEntity.AddInBox(0);
		}
		else
		{
			if (e.CardEntity.hasInBox)
			{
				e.CardEntity.RemoveInBox();
			}
		}
	}
}