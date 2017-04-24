using System.Collections.Generic;
using Network;

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
		Add(new PlayerMissionSetupSystem(contexts));

		//main-monolith
		{
			Add(new MissionBossMonolithSetupSystem(contexts));
			Add(new MissionBossMonolithCompletingSystem(contexts));
		}

		//player
		{
			Add(new PlayerMissionHunterCompletingSystem(contexts));
            Add(new KeeperAddedSystem(contexts));
            Add(new KeeperResloveMissionSystem(contexts));
		}
	}
}
