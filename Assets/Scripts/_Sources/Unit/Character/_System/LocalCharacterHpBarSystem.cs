using System.Collections.Generic;
using Entitas;


public class LocalCharacterHpBarSystem : ReactiveSystem<UnitEntity>
{
	private readonly HpBar _hpBar;

	public LocalCharacterHpBarSystem(Contexts contexts, HpBar hpBar) : base(contexts.unit)
	{
		_hpBar = hpBar;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Hitpoint);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasHitpoint && entity.owner.Entity.isLocal;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var e in entities)
		{
			_hpBar.UpdateHp(e.hitpoint.Value);
		}
	}
}