public class AbilityCollect : ActiveAbility<TileEntity>
{
	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), 1, true);
	}

	public override TileEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		return tile.hasCharge && tile.charge.Count > 0 ? tile : null;
	}

	public override void OnTargetSelected(UnitEntity caster, TileEntity target)
	{
		ReduceTileCharge(target);
		var card = CreateResourceCard(target.tileResource.Type);
		card.AddOwner(caster.owner.Entity);
	}

	private void ReduceTileCharge(TileEntity tile)
	{
		tile.ReplaceCharge(tile.charge.Count - 1);
	}

	private CardEntity CreateResourceCard(Resource type)
	{
		var entity = Contexts.sharedInstance.card.CreateEntity();
		entity.AddResourceCard(type);
		return entity;
	}
}