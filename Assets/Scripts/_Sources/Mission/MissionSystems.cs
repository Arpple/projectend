public class MissionSystems : Feature
{
	private GameUI _ui;

	public MissionSystems(Contexts contexts, GameUI ui) : base("Mission System")
	{
		_ui = ui;

		Add(new MainMissionSetupSystem(contexts));
		Add(new PlayerMissionSetupSystem(contexts));

		//main
		CreateMainMissionMonolith(contexts);
		CreateMainMissionDeadOrAlive(contexts);

		//player
		CreatePlayerMissionHunter(contexts);
		CreatePlayerMissionKeeper(contexts);
	}

	private void CreateMainMissionDeadOrAlive(Contexts contexts)
	{
		Add(new MissionDeadOrAliveSetupSystem(contexts));
		Add(new MissionDeadOrAliveFailSystem(contexts, _ui.WeatherResloveDisplayer));
	}

	private void CreatePlayerMissionHunter(Contexts contexts)
	{
		Add(new PlayerMissionHunterCompletingSystem(contexts));
		
	}

	private void CreatePlayerMissionKeeper(Contexts contexts)
	{
		Add(new KeeperAddedSystem(contexts));
		Add(new KeeperResloveMissionSystem(contexts));
	}

	private void CreateMainMissionMonolith(Contexts contexts)
	{
		Add(new MissionBossMonolithSetupSystem(contexts));
		Add(new MissionBossMonolithCompletingSystem(contexts));
	}
}