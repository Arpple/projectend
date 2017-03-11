namespace End.Game
{
	public class AbilityMove : Ability
	{
		public override void ActivateAbility(GameEntity sourceEntity, GameEntity targetEntity)
		{
			//TODO: use game event to sync across network
			sourceEntity.ReplaceMapPosition(targetEntity.mapPosition.x, targetEntity.mapPosition.y);
		}
	}

}
