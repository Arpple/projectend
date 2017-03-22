using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityMove : Ability
	{
		public override void ActivateAbility(GameEntity sourceEntity, GameEntity targetEntity)
		{
			Assert.IsTrue(sourceEntity.hasMapPosition);
			Assert.IsTrue(targetEntity.hasMapPosition);
			EventMove.Create(sourceEntity, targetEntity.mapPosition);
		}
	}

}
