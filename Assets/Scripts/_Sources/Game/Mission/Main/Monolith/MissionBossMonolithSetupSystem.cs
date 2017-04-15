public class MissionBossMonolithSetupSystem : MissionBossSetupSystem
{
	public MissionBossMonolithSetupSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Boss GetBossType()
	{
		return Boss.Monolith;
	}

	protected override MainMission GetMainMissionType()
	{
		return MainMission.BossMonolith;
	}
}