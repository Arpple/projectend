using System.Collections.Generic;
using Entitas;
using UnityEngine.Networking;

namespace End.Game
{
	public class GameSetupSystem : Feature
	{
		public GameSetupSystem(Contexts contexts, GameSetting setting, List<Player> players, Player localPlayer) : base("Game Setup")
		{
			//map
			Add(new CreateMapTileSystem(contexts, setting.MapSetting.GameMap.Load(), setting.MapSetting));
			Add(new CreateTileGraphSystem(contexts));

			//player
			Add(new CreatePlayerSystem(contexts, players));
			Add(new SetupLocalPlayerSystem(contexts, localPlayer));
			Add(new CreatePlayerCharacterSystem(contexts));
			Add(new RoleSetupSystem(contexts, setting.RoleSetting.GetRolesCount(players.Count)));

			//unit
			Add(new CharacterBlueprintLoadingSystem(contexts, setting.UnitSetting.CharacterSetting));
			Add(new CharacterIconLoadingSystem(contexts));

			//card
			Add(new CreatePlayerDeckSystem(contexts, UI.GameUI.Instance.CardContainer));
			Add(new CreatePlayerBoxSystem(contexts, UI.GameUI.Instance.BoxContainer));
			Add(new CreateDeckCardsSystem(contexts, setting.CardSetting.DeckSetting.Deck));
			
			//turn
			Add(new PlayingOrderSystem(contexts));

			if((NetworkController.Instance != null && NetworkController.IsServer) || GameController.Instance.IsOffline)
			{
				Add(new StartingDeckCardSystem(contexts, setting.CardSetting.DeckSetting));
			}
		}
	}
}

