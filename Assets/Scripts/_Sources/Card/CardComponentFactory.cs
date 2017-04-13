public partial class CardEntityFactory : EntityFactory<CardEntity, CardData>, IEntityFactory<CardEntity, CardData>
{
	private class CardComponentFactory : ComponentFactory<CardEntity, CardData>
	{
		private CacheList<string, Ability> _abilityCache;

		public CardComponentFactory(CardEntity entity, CardData data, CacheList<string, Ability> abilityCache) : base(entity, data)
		{
			_abilityCache = abilityCache;
		}

		public override void AddComponents()
		{
			AddSprite();
			AddAbility();
		}

		public void AddSprite()
		{
			if(_data.MainSprite != null)
			{
				_entity.AddSprite(_data.MainSprite);
			}
		}

		public void AddAbility()
		{
			_entity.AddAbility
			(
				_abilityCache.Get
				(
					_data.AbilityClassFullName,
					(name) => (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name)
				)
			);
		}
	}
}