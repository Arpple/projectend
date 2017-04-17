public partial class SkillCardEntityFactory : EntityFactory<CardEntity, SkillCardData>
{
	public class SkillCardComponentFactory : CardComponentFactory<SkillCardData>
	{
		private CacheList<string, Ability> _cacheAbility;

		public SkillCardComponentFactory(CardEntity entity, SkillCardData data, CacheList<string, Ability> cacheAbility) : base(entity, data)
		{
			_cacheAbility = cacheAbility;
		}

		public override void AddComponents()
		{
			base.AddComponents();
			AddAbility();
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
	}
}