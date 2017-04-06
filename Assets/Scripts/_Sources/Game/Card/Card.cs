namespace Game
{
	public enum Card
	{
		Move,
		Attack,
		Potion,
	}

	public static class CardExtension
	{
		public static GameEntity CreateCard(this GameContext context, Card type)
		{
			var entity = context.CreateEntity();
			entity.AddGameCard(type);
			return entity;
		}
	}
}

