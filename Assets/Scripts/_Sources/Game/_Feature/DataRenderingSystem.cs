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
			Add(new PlayerBoxCardAddSystem(contexts));
			Add(new PlayerDeckCardStatusSystem(contexts, ui.LocalPlayerStatus));

			//unit
			Add(new OnDeadBoxSystem(contexts));
			Add(new DeadSystem(contexts));
			Add(new LocalCharacterStatusSystem(contexts, ui.LocalPlayerStatus));

			//map
			Add(new RenderMapPositionSystem(contexts));

			//event
			Add(new RoleOriginWinningSystem(contexts));
			Add(new WinSystem(contexts));
		}
	}

}
