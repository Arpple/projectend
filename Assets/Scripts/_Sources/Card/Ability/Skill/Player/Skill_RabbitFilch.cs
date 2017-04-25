using System;

public class Skill_RabbitFilch: ActiveAbility<UnitEntity> {
    private UnitEntity _caster, _target;

    public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile) {
        return GetEnemyUnitFromTile(caster, tile);
    }

    public override TileEntity[] GetTilesArea(UnitEntity caster) {
        return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.VisionRange);
    }

    
    public override void OnTargetSelected(UnitEntity caster, UnitEntity target) {
        this._caster = caster;
        this._target = target;
        target.AddAbilityAggressiveEvent(target,1,rabbitFilch);
        //var entity = Contexts.sharedInstance.gameEvent.CreateEntity();
        //entity.AddAbilityAggressiveEvent(1, rabbitFilch);
    }

    private void rabbitFilch() {
        UnityEngine.Debug.Log("Cast Rabbit Filch");
        var cards = Contexts.sharedInstance.card.GetPlayerDeckCardsIncludeBox(_target.owner.Entity);
        var card = cards[ UnityEngine.Random.Range(0, Math.Max(0, cards.Length-1)) ];
        EventMoveDeckCard.MoveCardToPlayer(card, _caster.owner.Entity);
    }
}
