using System.Collections.Generic;
using Entitas;

public class BuffExhaustEffectSystem : BuffReactiveSystem
{
	private int _damageReduceAmount;

	public BuffExhaustEffectSystem(Contexts contexts, BuffSetting setting) : base(contexts)
	{
		_damageReduceAmount = setting.ExhaustDamageReduceAmount;
	}

	protected override Collector<BuffEntity> GetTrigger(IContext<BuffEntity> context)
	{
		return context.CreateCollector(BuffMatcher.BuffExhaust, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(BuffEntity entity)
	{
		return entity.hasTarget;
	}

	protected override void Execute(List<BuffEntity> entities)
	{
		foreach(var buff in entities)
		{
			var target = buff.target.Entity;
			var status = target.unitStatus;
			var atk = GetBuffAttackDamage(target, buff);

			target.ReplaceUnitStatus(status.HitPoint, atk, status.AttackRange, status.VisionRange, status.MoveSpeed);
		}
	}

	private int GetBuffAttackDamage(UnitEntity unit, BuffEntity buff)
	{
		var atk = unit.unitStatus.AttackPower;
		if (buff.isBuffExhaust)
		{
			atk -= _damageReduceAmount;
		}
		else
		{
			atk += _damageReduceAmount;
		}

		return atk;
	}
}