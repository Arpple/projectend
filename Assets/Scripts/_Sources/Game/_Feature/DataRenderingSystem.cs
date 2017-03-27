using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class DataRenderingSystem : Feature
	{
		public DataRenderingSystem(Contexts contexts, GameUI ui) : base("Data Rendering")
		{
			//deck card
			Add(new NewDeckCardToShareDeckSystem(contexts, ui.CardContainer.PlayerDecks[0]));
			Add(new RenderShareDeckSystem(contexts, ui.CardContainer.PlayerDecks[0]));
			Add(new RenderPlayerDeckSystem(contexts));

			Add(new RenderMapPositionSystem(contexts));
		}
	}

}
