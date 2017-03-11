using UnityEngine;

namespace End
{
	public abstract class Ability : MonoBehaviour
	{
		public abstract void ActivateAbility(GameEntity sourceEntity, GameEntity targetEntity);
	}
}
