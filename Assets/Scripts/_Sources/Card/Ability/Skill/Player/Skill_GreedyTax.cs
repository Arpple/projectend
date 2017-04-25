using System;

public class Skill_GreedyTax: ActiveAbility<TileEntity> {
    public override TileEntity[] GetTilesArea(UnitEntity caster) {
        return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), 1, true);
    }

    public override TileEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile) {
        return tile.hasCharge && tile.charge.Count > 0 ? tile : null;
    }

    public override void OnTargetSelected(UnitEntity caster, TileEntity target) {
        int multiple = ReduceTileCharge(target);
        for(int i = 1; i <= multiple; i++) {
            var card = CreateResourceCard(target.tileResource.Type);
            EventMoveDeckCard.MoveCardToPlayer(card, caster.owner.Entity);
        }
    }

    private int ReduceTileCharge(TileEntity tile) {
        int charge = tile.charge.Count;
        tile.ReplaceCharge(0);
        return charge;
    }

    private CardEntity CreateResourceCard(Resource type) {
        var entity = Contexts.sharedInstance.card.CreateEntity();
        entity.AddResourceCard(type);
        return entity;
    }
}
