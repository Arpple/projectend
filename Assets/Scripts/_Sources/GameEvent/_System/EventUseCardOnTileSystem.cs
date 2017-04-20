using Entitas;

public class EventUseCardOnTileSystem : EventSystem
{
	public EventUseCardOnTileSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventUseCardOnTile, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventUseCardOnTile;
	}

	protected override void Process(GameEventEntity entity)
	{
		var cardEvent = entity.eventUseCardOnTile;
		var ability = (ActiveAbility<TileEntity>)cardEvent.CardEnttiy.ability.Ability;
		ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEnttiy);

		if (cardEvent.CardEnttiy.hasDeckCard)
			RemovePlayerCard(cardEvent.CardEnttiy);

		EventLogger.ShowMessge(string.Format("{0} use {1}",
			cardEvent.UserEntity.owner.Entity.player,
			cardEvent.CardEnttiy.cardDescription.Name
		));
	}

	private void RemovePlayerCard(CardEntity card)
	{
		card.RemoveOwner();
		if (card.hasInBox) card.RemoveInBox();
	}
}