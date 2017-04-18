public class MissionBossMonolithCompletingSystem : MissionBossCompletingSystem
{
	public MissionBossMonolithCompletingSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Boss GetMissionBossType()
	{
		return Boss.Monolith;
	}
}
