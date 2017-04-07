using System.Collections.Generic;
using Entitas;
using UnityEngine.Networking;

namespace Game
{
	public class GameSetupSystems : Feature
	{
		public GameSetupSystems(Contexts contexts, GameSetting setting, List<Player> players, Player localPlayer) : base("Game Setup")
		{
			//map
			Add(new TileMapCreatingSystem(contexts, setting.MapSetting.GameMap.Load(), setting.MapSetting));
			Add(new TileGraphCreatingSystem(contexts));

			//player
			Add(new PlayerCreatingSystem(contexts, players));
			Add(new LocalPlayerSetupSystem(contexts, localPlayer));
			Add(new CreatePlayerCharacterSystem(contexts));	

			//unit
			Add(new CharacterBlueprintLoadingSystem(contexts, setting.UnitSetting.CharacterSetting));
			Add(new CharacterIconLoadingSystem(contexts));

			//card
			Add(new PlayerDeckCreatingSystem(contexts, UI.GameUI.Instance.DeckFactory));
			Add(new PlayerBoxCreatingSystem(contexts, UI.GameUI.Instance.BoxFactory));
			Add(new DeckCardCreatingSystem(contexts, setting.CardSetting.DeckSetting.Deck));

			Add(new CharacterSkillLoadingSystem(contexts));

			//turn
			Add(new GamePlayingOrderSystem(contexts));
			Add(new TurnAndRoundSetupSystem(contexts));

			if (IsServer())
			{
				Add(new StartDeckCardDrawingSystem(contexts, setting.CardSetting.DeckSetting));
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

