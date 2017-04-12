using System.Collections.Generic;
using Network;

public class GameSystems : Feature
{
	public GameSystems(Contexts contexts, List<Player> players, Player localPlayer, GameUI ui) 
		: base("Game System")
	{
		CreatePlayerSystems(contexts, players, localPlayer);
		CreateTurnSystems(contexts, ui);
		Add(new WinSystem(contexts));
	}

	private void CreatePlayerSystems(Contexts contexts, List<Player> players, Player localPlayer)
	{
		Add(new PlayerCreatingSystem(contexts, players));
		Add(new LocalPlayerSetupSystem(contexts, localPlayer));
	}

	private void CreateTurnSystems(Contexts contexts, GameUI ui)
	{
		Add(new PlayingOrderSetupSystem(contexts));
		Add(new TurnAndRoundSetupSystem(contexts));
		Add(new RoundEndPlayingOrderReOrderingSystem(contexts));
		Add(new PlayingFlagSystem(contexts));
		Add(new TurnPanelSystem(contexts, ui.TurnPanel));
		Add(new TurnNotificationSystem(contexts, ui.TurnNoti));

		if(GameController.Instance.IsOffline)
		{
			Add(new LocalCharacterFlagSystem(contexts));
		}
	}
}
