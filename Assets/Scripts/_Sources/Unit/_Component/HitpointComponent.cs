using Entitas;
using UnityEngine;

[Unit]
public class HitpointComponent : IComponent
{
	public int Value;
}

public static class HitpointExtension
{
	public static void TakeDamage(this UnitEntity entity, int amount)
	{
		if (!entity.hasHitpoint) return;

		entity.ReplaceHitpoint(Mathf.Max(1, entity.hitpoint.Value - amount));
	}

	public static void TakeFatalDamage(this UnitEntity entity, int amount)
	{
		if (!entity.hasHitpoint) return;

		entity.ReplaceHitpoint(Mathf.Max(0, entity.hitpoint.Value - amount));
	}

    public static void TakeDamage(this UnitEntity entity, int amount,bool canDead=false) {
        if(!entity.hasHitpoint) return;

        if(canDead)
            entity.TakeFatalDamage(amount);
        else
            entity.TakeDamage(amount);
    }

	public static void RecoverHitpoint(this UnitEntity entity, int amount)
	{
		if (!entity.hasHitpoint) return;

		entity.ReplaceHitpoint(Mathf.Min(entity.unitStatus.HitPoint, entity.hitpoint.Value + amount));
	}
}