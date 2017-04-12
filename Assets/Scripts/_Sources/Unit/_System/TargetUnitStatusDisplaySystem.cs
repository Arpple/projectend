using System.Collections.Generic;
using Entitas;

public class TargetUnitStatusDisplaySystem : ReactiveSystem<UnitEntity>
{
	private readonly PlayerUnitStatusPanel _panel;

	public TargetUnitStatusDisplaySystem(Contexts contexts, PlayerUnitStatusPanel panel) : base(contexts.unit)
	{
		_panel = panel;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return new Collector<UnitEntity>(
			new[] {
					context.GetGroup(UnitMatcher.Hitpoint),
					context.GetGroup(UnitMatcher.UnitStatus)
			},
			new[]
			{
					GroupEvent.Added,
					GroupEvent.Added,
			}
		);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return _panel.ShowingCharacter == entity && entity.hasHitpoint && entity.hasUnitStatus;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var e in entities)
		{
			_panel.UpdateUnitHitpoint(e.hitpoint);
			_panel.UpdateUnitStatus(e.unitStatus);
		}
	}
}