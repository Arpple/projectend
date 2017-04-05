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
			if (_lastCreatedCard == null) return 0;

			if (!_lastCreatedCard.hasGameCard) return 0;

			return _lastCreatedCard.gameCard.Id;
		}

	}
}

