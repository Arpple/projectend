using System.Collections.Generic;
using Entitas;

public class BuffExhaustExpireSystem : BuffReactiveSystem
{
	private int _damageReduceAmount;

	public BuffExhaustExpireSystem(Contexts contexts, BuffSetting setting) : base(contexts)
	{
		_damageReduceAmount = setting.ExhaustDamageReduceAmount;
	}

	protected override Collector<BuffEntity> GetTrigger(IContext<BuffEntity> context)
	{
		return context.CreateCollector(BuffMatcher.Duration, GroupEvent.Added);
	}

	protected override bool Filter(BuffEntity entity)
	{
		return entity.isBuffExhaust && entity.duration.Count == 0;
	}

	protected override void Execute(List<BuffEntity> entities)
	{
		foreach (var buff in entities)
		{
			var target = buff.target.Entity;
			var status = target.unitStatus;
			var atk = status.AttackPower + _damageReduceAmount;

			target.ReplaceUnitStatus(status.HitPoint, atk, status.AttackRange, status.VisionRange, status.MoveSpeed);
		}
	}
}