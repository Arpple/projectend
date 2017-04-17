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
		AddCardDescription();
	}

	private void AddSprite()
	{
		if (_data.MainSprite != null)
		{
			_entity.AddSprite(_data.MainSprite);
		}
	}

	private void AddCardDescription()
	{
		_entity.AddCardDescription(_data.Name, _data.ActiveDesc, _data.PassiveDesc);
	}
}