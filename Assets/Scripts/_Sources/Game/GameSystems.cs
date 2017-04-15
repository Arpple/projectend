using System.Collections.Generic;
using Network;
using Offline;

public class GameSystems : Feature
{
	public GameSystems(Contexts contexts, List<Player> players, Player localPlayer)
		: base("Game System")
	{
		CreatePlayerSystems(contexts, players, localPlayer);
		CreateMissionSystem(contexts);
		Add(new WinSystem(contexts));
	}

	private void CreatePlayerSystems(Contexts contexts, List<Player> players, Player localPlayer)
	{
		Add(new PlayerCreatingSystem(contexts, players));
		Add(new LocalPlayerSetupSystem(contexts, localPlayer));
	}

	private void CreateMissionSystem(Contexts contexts)
	{
		Add(new MainMissionSetupSystem(contexts));

		//main-monolith
		{
			Add(new MissionBossMonolithSetupSystem(contexts));
			Add(new MissionBossMonolithCompletingSystem(contexts));
		}
	}
}
