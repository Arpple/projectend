using UnityEngine;

namespace End.Game
{
	public abstract class Ability : MonoBehaviour
	{
		public abstract void ActivateAbility(GameEntity sourceEntity, GameEntity targetEntity);
	}
}
