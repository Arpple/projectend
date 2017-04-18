using Entitas;

public class SkillCardDataLoadingSystem : DataLoadingSystem<CardEntity, SkillCardData>
{
	private SkillCardSetting _setting;

	public SkillCardDataLoadingSystem(Contexts contexts, SkillCardSetting setting) : base(contexts.card)
	{
		_setting = setting;
	}

	protected override IEntityFactory<CardEntity, SkillCardData> CreateEntityFactory(IContext<CardEntity> context)
	{
		return new SkillCardEntityFactory(context);
	}

	protected override SkillCardData GetData(CardEntity entity)
	{
		return _setting.GetData(entity.skillCard.Type);
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.SkillCard);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasSkillCard;
	}
}