using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityMove : Ability
	{
		public override void ActivateAbility(GameEntity sourceEntity)
		{
			Assert.IsTrue(sourceEntity.hasMapPosition);
			//TODO: use selector
			//EventMove.Create(sourceEntity, targetEntity.mapPosition);
		}
	}

}
