using Entitas;

public class EventUseCardOnUnitSystem : EventSystem
{
	public EventUseCardOnUnitSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventUseCardOnUnit, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventUseCardOnUnit;
	}

	protected override void Process(GameEventEntity entity)
	{
		var cardEvent = entity.eventUseCardOnUnit;
		var ability = (ActiveAbility<UnitEntity>)cardEvent.CardEntity.ability.Ability;
		ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEntity);

		if (cardEvent.CardEntity.hasDeckCard)
			RemovePlayerCard(cardEvent.CardEntity);
	}

	private void RemovePlayerCard(CardEntity card)
	{
		card.RemoveOwner();
		if (card.hasInBox) card.RemoveInBox();
	}
}
