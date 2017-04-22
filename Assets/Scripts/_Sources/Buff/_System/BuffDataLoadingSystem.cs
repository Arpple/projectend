using System.Collections.Generic;
using Entitas;

public class BuffDataLoadingSystem : BuffReactiveSystem
{
	private BuffSetting _setting;

	public BuffDataLoadingSystem(Contexts contexts, BuffSetting setting) : base(contexts)
	{
		_setting = setting;
	}

	protected override Collector<BuffEntity> GetTrigger(IContext<BuffEntity> context)
	{
		return context.CreateCollector(BuffMatcher.Buff);
	}

	protected override bool Filter(BuffEntity entity)
	{
		return entity.hasBuff;
	}

	protected override void Execute(List<BuffEntity> entities)
	{
		foreach(var e in entities)
		{
			LoadData(e, _setting.GetData(e.buff.Type));
		}
	}

	private void LoadData(BuffEntity entity, BuffData data)
	{
		entity.AddSprite(data.Icon);
		entity.AddDuration(data.Duration);
	}
}