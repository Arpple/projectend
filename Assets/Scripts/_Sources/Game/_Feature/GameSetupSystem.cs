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

			//unit
			Add(new CharacterBlueprintLoadingSystem(contexts, setting.UnitSetting.CharacterSetting));
			Add(new CharacterIconLoadingSystem(contexts));

			//card
			Add(new CreatePlayerDeckSystem(contexts, UI.GameUI.Instance.DeckFactory));
			Add(new CreatePlayerBoxSystem(contexts, UI.GameUI.Instance.BoxFactory));
			Add(new CreateDeckCardsSystem(contexts, setting.CardSetting.DeckSetting.Deck));

			Add(new CharacterSkillLoadingSystem(contexts));

			//turn
			Add(new PlayingOrderSystem(contexts));

			if(IsServer())
			{
				Add(new StartingDeckCardSystem(contexts, setting.CardSetting.DeckSetting));
			}

			if (IsOffline())
			{
				Add(new RoleSetupSystem(contexts, setting.RoleSetting.GetRolesCount(players.Count)));
			}
			else
			{
				Add(new RoleLoadingSystem(contexts));
			}
		}

		private bool IsServer()
		{
			return (NetworkController.Instance != null && NetworkController.IsServer) || IsOffline();
		}
		
		private bool IsOffline()
		{
			return GameController.Instance.IsOffline;
		}
	}
}

