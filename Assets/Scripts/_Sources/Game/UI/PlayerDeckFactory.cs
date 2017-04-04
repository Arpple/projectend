namespace Game.UI
{
	public class PlayerDeckFactory : CardContainerFactory<CardContainer>
	{
		public CardContainer CreateContainer(int playerId)
		{
			return base.CreateContainer("Deck", playerId);
		}

		public override void Init()
		{
			base.Init();
			var middleDeck = CreateContainer(0);
			middleDeck.name = "Middle Deck";
		}
	}
}
