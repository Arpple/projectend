using System.Collections.Generic;
using System.Linq;
using Entitas;

public class LocalCharacterStatusRenderingSystem : ReactiveSystem<UnitEntity>
{
	private readonly PlayerUnitStatusPanel _ui;

	public LocalCharacterStatusRenderingSystem(Contexts contexts, PlayerUnitStatusPanel ui) : base(contexts.unit)
	{
		_ui = ui;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.UnitStatus, GroupEvent.Added);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasUnitStatus && entity.isLocal;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var entity in entities)
		{
			_ui.UpdateUnitStatus(entity.unitStatus);
		}
	}
}