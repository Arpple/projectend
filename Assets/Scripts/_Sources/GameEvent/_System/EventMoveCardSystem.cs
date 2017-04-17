using Entitas;

public class EventMoveCardSystem : EventSystem
{
	public EventMoveCardSystem(Contexts contexts) : base(contexts) { }

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventMoveDeckCard, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventMoveDeckCard;
	}

	protected override void Process(GameEventEntity entity)
	{
		var e = entity.eventMoveDeckCard;

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