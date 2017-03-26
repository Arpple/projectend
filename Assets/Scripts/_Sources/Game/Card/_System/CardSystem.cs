using Entitas;

namespace End.Game
{
	public class CardSystem : Feature
	{
		public CardSystem(Contexts contexts) : base("Deck System")
		{
			var cardContainer = UI.GameUI_Old.Instance.InventoryGroup.CardContainer;

			//card

			//deck card
			Add(new RenderShareDeckSystem(contexts, cardContainer));
			Add(new RenderPlayerDeckSystem(contexts));

			//box card

			//skill card


		}
	}

}
