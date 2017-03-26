using System.Collections.Generic;
using Entitas;

namespace End.Game
{
	public class GameSetupSystem : Feature
	{
		public GameSetupSystem(Contexts contexts, GameSetting setting, List<Player> players, Player localPlayer) : base("Game Setup")
		{
			//player
			Add(new LoadPlayerSystem(contexts, players));
			Add(new SetupLocalPlayerSystem(contexts, localPlayer));
			Add(new CreatePlayerCharacterSystem(contexts));

			//map
			Add(new CreateMapTileSystem(contexts, setting.MapSetting.GameMap.Load(), setting.MapSetting));
			Add(new CreateTileGraphSystem(contexts));
			Add(new CreateTileActionSystem(contexts));

			//card
			Add(new CreatePlayerDeckSystem(contexts, UI.GameUI_Old.Instance.InventoryGroup.CardContainer));
			Add(new CreateDeckCardsSystem(contexts, setting.CardSetting.Deck));
			
			//turn
			Add(new PlayingOrderSystem(contexts, players));

			if(localPlayer.isServer || GameController.Instance.IsOffline)
			{
				Add(new StartingDeckCardSystem(contexts, setting.CardSetting));
			}
		}
	}
}

