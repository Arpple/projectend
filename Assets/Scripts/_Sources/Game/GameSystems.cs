using System.Collections.Generic;
using Network;

public class GameSystems : Feature
{
	public GameSystems(Contexts contexts, List<Player> players, Player localPlayer)
		: base("Game System")
	{
		CreatePlayerSystems(contexts, players, localPlayer);
		Add(new WinSystem(contexts));
	}

	private void CreatePlayerSystems(Contexts contexts, List<Player> players, Player localPlayer)
	{
		Add(new PlayerCreatingSystem(contexts, players));
		Add(new LocalPlayerSetupSystem(contexts, localPlayer));
		Add(new AllPlayerDeadGameEnd(contexts));
	}
}
