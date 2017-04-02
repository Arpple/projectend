using UnityEngine;
using Entitas;

namespace End.Game.UI
{
	public class GameUISystem : Feature
	{
		public GameUISystem(Contexts contexts, GameUI ui) : base("UI")
		{
			Add(new NewDeckCardToShareDeckSystem(contexts, ui.CardContainer.PlayerDecks[0]));
			Add(new RenderShareDeckSystem(contexts, ui.CardContainer.PlayerDecks[0]));

			Add(new PlayerDeckCardStatusSystem(contexts, ui.LocalPlayerStatus));
			Add(new PlayerBoxCardStatusSystem(contexts, ui.LocalPlayerStatus));

			Add(new LocalCharacterStatusSystem(contexts, ui.LocalPlayerStatus));
			Add(new TurnPanelSetupSystem(contexts, ui.TurnPanel));

			Add(new LocalCharacterHpBarSystem(contexts, ui.LocalPlayerStatus.HpBar));
		}
	}

}
