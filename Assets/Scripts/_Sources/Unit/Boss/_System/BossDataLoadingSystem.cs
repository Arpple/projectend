using Entitas;

public class BossDataLoadingSystem : DataLoadingSystem<UnitEntity, BossData>
{
	BossSetting _setting;

	public BossDataLoadingSystem(Contexts contexts, BossSetting setting) : base(contexts.unit)
	{
		_setting = setting;
	}

	protected override IEntityFactory<UnitEntity, BossData> CreateEntityFactory(IContext<UnitEntity> context)
	{
		return new BossEntityFactory(context);
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.BossUnit);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasBossUnit;
	}

	protected override BossData GetData(UnitEntity entity)
	{
		return _setting.GetData(entity.bossUnit.Type);
	}


}
