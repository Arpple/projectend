public abstract class CardComponentFactory<TCardData> : ComponentFactory<CardEntity, TCardData>
	where TCardData : CardData
{
	private CacheList<string, Ability> _abilityCache;

	public CardComponentFactory(CardEntity entity, TCardData data) : base(entity, data)
	{
	}

	public override void AddComponents()
	{
		AddSprite();
	}

	public void AddSprite()
	{
		if (_data.MainSprite != null)
		{
			_entity.AddSprite(_data.MainSprite);
		}
	}

	
}