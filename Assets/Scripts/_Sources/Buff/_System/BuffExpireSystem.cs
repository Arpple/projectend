using System.Collections.Generic;
using Entitas;

public class BuffExpireSystem : BuffReactiveSystem
{
	public BuffExpireSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<BuffEntity> GetTrigger(IContext<BuffEntity> context)
	{
		return context.CreateCollector(BuffMatcher.Duration);
	}

	protected override bool Filter(BuffEntity entity)
	{
		return entity.hasDuration && entity.duration.Count == 0;
	}

	protected override void Execute(List<BuffEntity> entities)
	{
		foreach (var e in entities)
		{
			e.buffTarget.Entity.buffList.List.Remove(e);
			e.Destroy();
		}
	}
}