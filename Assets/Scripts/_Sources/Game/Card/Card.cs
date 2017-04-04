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
			entity.AddCard((short)GetNextCardId(), type);

			_lastCreatedCard = entity;
			return entity;
		}

		private static int GetNextCardId()
		{
			return _lastCreatedCard == null
				? 0
				: _lastCreatedCard.card.Id + 1;
		}

	}
}

