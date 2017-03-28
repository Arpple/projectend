using System.Collections.Generic;
using Entitas;
using UnityEngine.Networking;

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

			//card
			Add(new CreatePlayerDeckSystem(contexts, UI.GameUI.Instance.CardContainer));
			Add(new CreateDeckCardsSystem(contexts, setting.CardSetting.DeckSetting.Deck));
			
			//turn
			Add(new PlayingOrderSystem(contexts, players));

			if((NetworkController.Instance != null && NetworkController.IsServer) || GameController.Instance.IsOffline)
			{
				Add(new StartingDeckCardSystem(contexts, setting.CardSetting.DeckSetting));
			}
		}
	}
}

