using Entitas;

public partial class BossEntityFactory : UnitEntityFactory, IEntityFactory<UnitEntity, BossData>
{
	public BossEntityFactory(IContext<UnitEntity> context) : base(context)
	{
	}

	public void AddComponents(UnitEntity entity, BossData data)
	{
		var compFact = new BossComponentFactory(entity, data);
		compFact.AddComponents();
	}

	public UnitEntity CreateEntityWithComponents(BossData data)
	{
		var entity = _context.CreateEntity();
		AddComponents(entity, data);
		return entity;
	}
}