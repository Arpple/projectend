public static class CardExtension
{
	public static CardEntity CreateCard(this CardContext context, Card type)
	{
		var entity = context.CreateEntity();
		entity.AddCard(type);
		return entity;
	}
}