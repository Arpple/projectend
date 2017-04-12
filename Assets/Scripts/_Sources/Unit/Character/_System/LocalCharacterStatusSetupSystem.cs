using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

public class LocalCharacterStatusSetupSystem : ReactiveSystem<UnitEntity>
{
	private PlayerUnitStatusPanel _panel;

	public LocalCharacterStatusSetupSystem(Contexts contexts, PlayerUnitStatusPanel statusPanel) : base(contexts.unit)
	{
		_panel = statusPanel;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Local);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.isLocal;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach(var e in entities)
		{
			_panel.SetCharacter(e);
		}
	}
}