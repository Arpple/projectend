using Entitas;

public partial class ResourceCardEntityFactory : EntityFactory<CardEntity, ResourceCardData>, IEntityFactory<CardEntity, ResourceCardData>
{
	public ResourceCardEntityFactory(IContext<CardEntity> context) : base(context)
	{
	}

	protected override ComponentFactory<CardEntity, ResourceCardData> CreateComponentFactory(CardEntity entity, ResourceCardData data)
	{
		return new ResourceCardComponentFactory(entity, data);
	}
}