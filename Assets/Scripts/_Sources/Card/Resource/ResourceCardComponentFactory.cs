public partial class ResourceCardEntityFactory : EntityFactory<CardEntity, ResourceCardData>
{
	public class ResourceCardComponentFactory : CardComponentFactory<ResourceCardData>
	{
		public ResourceCardComponentFactory(CardEntity entity, ResourceCardData data) : base(entity, data)
		{
		}
	}
}