public partial class DeckCardEntityFactory : EntityFactory<CardEntity, DeckCardData>
{
	public class DeckCardComponentFactory : CardComponentFactory<DeckCardData>
	{
		private CacheList<string, Ability> _cacheAbility;

		public DeckCardComponentFactory(CardEntity entity, DeckCardData data, CacheList<string, Ability> cacheAbility) : base(entity, data)
		{
			_cacheAbility = cacheAbility;
		}

		public override void AddComponents()
		{
			base.AddComponents();
			AddAbility();
			AddAbilityEffect();
		}

		public void AddAbility()
		{
			_entity.AddAbility
			(
				_cacheAbility.Get
				(
					_data.AbilityClassFullName,
					(name) => (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name)
				)
			);
		}

		public void AddAbilityEffect()
		{
			if (_data.Effect != null)
			{
				_entity.AddAbilityEffect(_data.Effect);
			}
		}
	}
}