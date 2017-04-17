using Entitas;

public class DeckCardDataLoadingSystem : DataLoadingSystem<CardEntity, DeckCardData>
{
	private DeckSetting _setting;

	public DeckCardDataLoadingSystem(Contexts contexts, DeckSetting setting) : base(contexts.card)
	{
		_setting = setting;
	}

	protected override IEntityFactory<CardEntity, DeckCardData> CreateEntityFactory(IContext<CardEntity> context)
	{
		return new DeckCardEntityFactory(context);
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.DeckCard);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasDeckCard;
	}

	protected override DeckCardData GetData(CardEntity entity)
	{
		return _setting.GetCardData(entity.deckCard.Type);
	}
}