using System;
using System.Collections.Generic;
using Entitas;
public class DealDamageSystem: ReactiveSystem<UnitEntity> {
    public DealDamageSystem(Contexts contexts) : base(contexts.unit) {

    }
    protected override void Execute(List<UnitEntity> entities) {
        foreach (var player in entities) {
            AbilityDamageComponent damage = player.abilityDamage;
            player.TakeDamage(damage.damage,damage.canMakeDead);
            player.RemoveAbilityDamage();
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return entity.hasAbilityDamage && entity.hasHitpoint;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector<UnitEntity>(UnitMatcher.AbilityDamage, GroupEvent.Added);
    }
}
