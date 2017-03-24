using Entitas;

namespace End.Game
{
	public class DeckSystem : Feature
	{
		public DeckSystem(Contexts contexts, DeckSetting setting) : base("Deck System")
		{
			var cardContainer = UI.GameUI.Instance.InventoryGroup.CardContainer;

			Add(new CreatePlayerDeckSystem(contexts, cardContainer));
			Add(new CreatePlayerBoxSystem(contexts));

			Add(new CreateDeckCardsSystem(contexts, setting.CardSetting.Deck));

			Add(new RenderMiddleDeckSystem(contexts, cardContainer));
			Add(new RenderPlayerDeckSystem(contexts));

			Add(new LoadCardSystem(contexts, setting.CardSetting));

		}
	}

}
