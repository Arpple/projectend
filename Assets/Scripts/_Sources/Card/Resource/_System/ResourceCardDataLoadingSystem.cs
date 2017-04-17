using Entitas;

public class ResourceCardDataLoadingSystem : DataLoadingSystem<CardEntity, ResourceCardData>
{
	private ResourceCardSetting _setting;

	public ResourceCardDataLoadingSystem(Contexts contexts, ResourceCardSetting setting) : base(contexts.card)
	{
		_setting = setting;
	}

	protected override IEntityFactory<CardEntity, ResourceCardData> CreateEntityFactory(IContext<CardEntity> context)
	{
		return new ResourceCardEntityFactory(context);
	}

	protected override ResourceCardData GetData(CardEntity entity)
	{
		return _setting.GetCardData(entity.cardResource.Type);
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.CardResource);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasCardResource;
	}
}