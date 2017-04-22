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

		if(cardEvent.CardEntity.hasAbilityEffect)
		{
			cardEvent.CardEntity.abilityEffect.EffectObject.PlayAnimation();
		}

		if (cardEvent.CardEntity.hasDeckCard)
			RemovePlayerCard(cardEvent.CardEntity);

		var msg = string.Format("{0} use {1}",
			cardEvent.UserEntity.owner.Entity.player,
			cardEvent.CardEntity.cardDescription.Name
		);
		
		if(cardEvent.TargetEntity != cardEvent.UserEntity)
		{
			msg += " to " + cardEvent.TargetEntity.owner.Entity.player;
		}

		EventLogger.ShowMessge(msg);
	}

	private void RemovePlayerCard(CardEntity card)
	{
		card.RemoveOwner();
		if (card.hasInBox) card.RemoveInBox();
	}
}
