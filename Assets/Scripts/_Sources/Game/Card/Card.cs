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
		private static GameEntity _lastCreatedCard;

		public static GameEntity CreateCard(this GameContext context, Card type)
		{
			var entity = context.CreateEntity();
			entity.AddGameCard((short)GetNextCardId(), type);

			_lastCreatedCard = entity;
			return entity;
		}

		private static int GetNextCardId()
		{
			return _lastCreatedCard == null
				? 0
				: _lastCreatedCard.gameCard.Id + 1;
		}

	}
}

