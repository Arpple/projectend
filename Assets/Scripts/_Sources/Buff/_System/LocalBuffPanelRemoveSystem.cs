using System.Collections.Generic;
using Entitas;

public class LocalBuffPanelRemoveSystem : BuffReactiveSystem
{
	private BuffPanel _panel;

	public LocalBuffPanelRemoveSystem(Contexts contexts, BuffPanel panel) : base(contexts)
	{
		_panel = panel;
	}

	protected override Collector<BuffEntity> GetTrigger(IContext<BuffEntity> context)
	{
		return context.CreateCollector(BuffMatcher.Duration);
	}

	protected override bool Filter(BuffEntity entity)
	{
		return IsBuffExpired(entity) && IsLocalBuff(entity);
	}

	protected override void Execute(List<BuffEntity> entities)
	{
		foreach(var buff in entities)
		{
			_panel.RemoveBuff(buff);
		}
	}

	private bool IsBuffExpired(BuffEntity buff)
	{
		return buff.hasDuration && buff.duration.Count == 0;
	}

	private bool IsLocalBuff(BuffEntity buff)
	{
		return buff.hasTarget && buff.target.Entity.isLocal;
	}
}