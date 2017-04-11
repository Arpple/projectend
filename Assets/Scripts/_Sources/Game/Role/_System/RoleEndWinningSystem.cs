using System.Collections.Generic;
using Entitas;

public class RoleEndWinningSystem : ReactiveSystem<UnitEntity>
{
	public RoleEndWinningSystem(Contexts contexts) : base(contexts.unit)
	{

	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Dead, GroupEvent.Added);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.isDead && entity.owner.Entity.role.RoleObject is RoleEnd;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var e in entities)
		{
			e.owner.Entity.isWinner = true;
		}
	}
}

