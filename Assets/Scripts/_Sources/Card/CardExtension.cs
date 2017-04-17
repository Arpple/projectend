public static class CardExtension
{
	public static CardEntity CreateDeckCard(this CardContext context, DeckCard type)
	{
		var entity = context.CreateEntity();
		entity.AddDeckCard(type);
		return entity;
	}
}