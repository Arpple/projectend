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

			Add(new LocalPlayerDeckCardStatusSystem(contexts, ui.LocalPlayerStatus));
			Add(new TargetPlayerDeckCardStatusSystem(contexts, ui.TargetPlayerStatus));
		}
	}

}
