namespace Game
{
	public enum Card
	{
		//Deck
		Move,
		Attack,
		Potion,

		//Skill
		Test
	}

	public static class CardExtension
	{
		public static CardEntity CreateCard(this CardContext context, Card type)
		{
			var entity = context.CreateEntity();
			entity.AddGameCard(type);
			return entity;
		}
	}
}

