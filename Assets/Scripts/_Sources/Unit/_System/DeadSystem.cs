using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.Assertions;

public class DeadSystem : ReactiveSystem<UnitEntity>
{
	//private readonly GameContext _context;

	public DeadSystem(Contexts contexts) : base(contexts.unit)
	{
		//_context = contexts.game;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Hitpoint, GroupEvent.Added);
	}

	protected override bool Filter(UnitEntity entity)
	{
		Assert.IsFalse(entity.hitpoint.Value < 0);

		return entity.hitpoint.Value == 0;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var e in entities)
		{
			e.isDead = true;
		}

		if(entities.Count > 0)
		{
			EventLogger.ShowMessge(
				string.Join(",", entities.Select(e => e.owner.Entity.player.ToString()).ToArray())
				+ " dead");
		}
	}
}