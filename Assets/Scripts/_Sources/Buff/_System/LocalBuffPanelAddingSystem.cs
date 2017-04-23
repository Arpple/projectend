using System.Collections.Generic;
using Entitas;

public class LocalBuffPanelAddingSystem : BuffReactiveSystem
{
	private BuffPanel _panel;

	public LocalBuffPanelAddingSystem(Contexts contexts, BuffPanel panel) : base(contexts)
	{
		_panel = panel;
	}

	protected override Collector<BuffEntity> GetTrigger(IContext<BuffEntity> context)
	{
		return context.CreateCollector(BuffMatcher.Target);
	}

	protected override bool Filter(BuffEntity entity)
	{
		return entity.hasTarget && entity.target.Entity.isLocal;
	}

	protected override void Execute(List<BuffEntity> entities)
	{
		foreach(var buff in entities)
		{
			_panel.AddBuff(buff);
		}
	}
}