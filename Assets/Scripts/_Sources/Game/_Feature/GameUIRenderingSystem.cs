using UnityEngine;
using Entitas;

namespace End.Game.UI
{
	public class GameUIRenderingSystem : Feature
	{
		public GameUIRenderingSystem(Contexts contexts, GameUI ui) : base("UI")
		{
			Add(new NewDeckCardToShareDeckSystem(contexts, ui.CardContainer.PlayerDecks[0]));
			Add(new RenderShareDeckSystem(contexts, ui.CardContainer.PlayerDecks[0]));

			Add(new PlayerDeckCardStatusSystem(contexts, ui.LocalPlayerStatus));
			Add(new PlayerBoxCardStatusSystem(contexts, ui.LocalPlayerStatus));
		}
	}

}
