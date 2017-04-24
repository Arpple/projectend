using System.Linq;
using System.Collections.Generic;
using Entitas;

public class BlockAttackSystem: ReactiveSystem<UnitEntity> {

    public BlockAttackSystem(Contexts context) : base(context.unit) {

    }

    protected override bool Filter(UnitEntity entity) {
        return entity.hasOwner && entity.hasHitpoint;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector<UnitEntity>(UnitMatcher.AbilityAttack,GroupEvent.Added);
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach(var player in entities) {

            AbilityAttackComponent damage = player.abilityAttack;
            if(SearchBox(player.owner.Entity, damage.BlockCount)) {
                player.RemoveAbilityAttack();
                removeUseCard(player.owner.Entity,damage.BlockCount);
            } else {
                player.AddAbilityDamage(damage.AttackPower,damage.canMakeDead);
                player.RemoveAbilityAttack();
            }
        }
    }

    private bool SearchBox(GameEntity player,int needBlock) {
        int blockCount = 0;
        var playerBoxs = Contexts.sharedInstance.card.GetPlayerBoxCards(player);
        foreach(var card in playerBoxs ) {
            IBlockAttack b = card.ability.Ability as IBlockAttack;
            if(b is IBlockAttack) {
                blockCount ++ ;
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
            IBlockAttack b = card.ability.Ability as IBlockAttack;
            if(b is IBlockAttack) {
                b.AfterBlockAttack(card);
                blockCount++;
                if(blockCount >= count) {
                    return;
                }
            }
        }
    }

}
