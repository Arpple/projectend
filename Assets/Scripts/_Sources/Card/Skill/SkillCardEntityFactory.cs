using Entitas;

public partial class SkillCardEntityFactory : EntityFactory<CardEntity, SkillCardData>, IEntityFactory<CardEntity, SkillCardData>
{
	private CacheList<string, Ability> _cacheAbility;

	public SkillCardEntityFactory(IContext<CardEntity> context) : base(context)
	{
		_cacheAbility = new CacheList<string, Ability>();
	}

	protected override ComponentFactory<CardEntity, SkillCardData> CreateComponentFactory(CardEntity entity, SkillCardData data)
	{
		return new SkillCardComponentFactory(entity, data, _cacheAbility);
	}
}