using Entitas;
using UnityEngine;

namespace End.Game
{
	[Game]
	public class HitpointComponent : IComponent
	{
		public int HitPoint;
	}

	public static class HitPointExtension
	{
		public static void ModifyHitpoint(this GameEntity entity, int modifyValue)
		{
			int newHp = Mathf.Clamp(entity.hitpoint.HitPoint + modifyValue, 0, entity.unitStatus.HitPoint);
			entity.ReplaceHitpoint(newHp);
		}
	}
}
