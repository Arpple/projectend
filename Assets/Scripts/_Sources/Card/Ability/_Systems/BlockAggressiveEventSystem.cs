using System.Linq;
using System.Collections.Generic;
using Entitas;

public class BlockAggressiveEventSystem: ReactiveSystem<UnitEntity> {

    public BlockAggressiveEventSystem(Contexts context) : base(context.unit) {

    }

    protected override bool Filter(UnitEntity entity) {
        return true;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector<UnitEntity>(UnitMatcher.AbilityAggressiveEvent, GroupEvent.Added);
    }

    protected override void Execute(List<UnitEntity> entities) {
        UnityEngine.Debug.Log("Event AGG ADDED");
        foreach(var target in entities) {
            AbilityAggressiveEventComponent abilityEffect = target.abilityAggressiveEvent;
            var player = target.owner.Entity;
            if(SearchBox(player, abilityEffect.blockCount)) {
                UnityEngine.Debug.Log("Block Agg event");
                removeUseCard(player, abilityEffect.blockCount);
                target.RemoveAbilityAggressiveEvent();
            } else {
                UnityEngine.Debug.Log("cannot block agg evet");
                abilityEffect.activeAbilityFunction();
                target.RemoveAbilityAggressiveEvent();
            }
        }
    }

    private bool SearchBox(GameEntity player, int needBlock) {
        int blockCount = 0;
        var playerBoxs = Contexts.sharedInstance.card.GetPlayerBoxCards(player);
        foreach(var card in playerBoxs) {
            IProtectAggressiveAbility b = card.ability.Ability as IProtectAggressiveAbility;
            if(b is IProtectAggressiveAbility) {
                blockCount++;
                if(blockCount >= needBlock)
                    return true;
            }
        }
        return false;
    }

    private void removeUseCard(GameEntity player, int count) {
        int blockCount = 0;
        var playerBoxs = Contexts.sharedInstance.card.GetPlayerBoxCards(player);
        foreach(var card in playerBoxs) {
            IProtectAggressiveAbility b = card.ability.Ability as IProtectAggressiveAbility;
            if(b is IProtectAggressiveAbility) {
                b.AfterBlock(card);
                blockCount++;
                if(blockCount >= count) {
                    return;
                }
            }
        }
    }

}
