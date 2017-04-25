public class MissionSystems : Feature
{
	public MissionSystems(Contexts contexts) : base("Mission System")
	{
		Add(new MainMissionSetupSystem(contexts));
		Add(new PlayerMissionSetupSystem(contexts));

		//main
		CreateMainMissionMonolith(contexts);
		CreateMainMissionDeadOrAlive(contexts);

		//player
		CreatePlayerMissionHunter(contexts);
	}

	private void CreateMainMissionDeadOrAlive(Contexts contexts)
	{
		Add(new MissionDeadOrAliveSetupSystem(contexts));
		Add(new MissionDeadOrAliveFailSystem(contexts));
	}

	private void CreatePlayerMissionHunter(Contexts contexts)
	{
		Add(new PlayerMissionHunterCompletingSystem(contexts));
		Add(new KeeperAddedSystem(contexts));
		Add(new KeeperResloveMissionSystem(contexts));
	}

	private void CreateMainMissionMonolith(Contexts contexts)
	{
		Add(new MissionBossMonolithSetupSystem(contexts));
		Add(new MissionBossMonolithCompletingSystem(contexts));
	}
}