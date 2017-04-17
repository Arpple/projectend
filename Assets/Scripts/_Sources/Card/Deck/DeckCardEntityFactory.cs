using Entitas;

public partial class DeckCardEntityFactory : EntityFactory<CardEntity, DeckCardData>, IEntityFactory<CardEntity, DeckCardData>
{
	private CacheList<string, Ability> _cacheAbility;

	public DeckCardEntityFactory(IContext<CardEntity> context) : base(context)
	{
		_cacheAbility = new CacheList<string, Ability>();
	}

	protected override ComponentFactory<CardEntity, DeckCardData> CreateComponentFactory(CardEntity entity, DeckCardData data)
	{
		return new DeckCardComponentFactory(entity, data, _cacheAbility);
	}
}