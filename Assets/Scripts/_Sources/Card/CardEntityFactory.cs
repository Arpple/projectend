using Entitas;

public partial class CardEntityFactory : EntityFactory<CardEntity, CardData>, IEntityFactory<CardEntity, CardData>
{
	private CacheList<string, Ability> _abilityCache;

	public CardEntityFactory(IContext<CardEntity> context) : base(context)
	{
		_abilityCache = new CacheList<string, Ability>();
	}

	protected override ComponentFactory<CardEntity, CardData> CreateComponentFactory(CardEntity entity, CardData data)
	{
		return new CardComponentFactory(entity, data, _abilityCache);
	}
}