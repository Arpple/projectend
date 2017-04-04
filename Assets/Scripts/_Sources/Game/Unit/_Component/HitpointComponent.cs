using Entitas;
using UnityEngine;

namespace Game
{
	[Game]
	public class HitpointComponent : IComponent
	{
		public int Value;
	}

	public static class HitpointExtension
	{
		public static void TakeDamage(this GameEntity entity, int amount)
		{
			if (!entity.hasGameHitpoint) return;

			entity.ReplaceGameHitpoint(Mathf.Max(1, entity.gameHitpoint.Value - amount));
		}

		public static void TakeFatalDamage(this GameEntity entity, int amount)
		{
			if (!entity.hasGameHitpoint) return;

			entity.ReplaceGameHitpoint(Mathf.Max(0, entity.gameHitpoint.Value - amount));
		}

		public static void RecoverHitpoint(this GameEntity entity, int amount)
		{
			if (!entity.hasGameHitpoint) return;

			entity.ReplaceGameHitpoint(Mathf.Min(entity.gameUnitStatus.HitPoint, entity.gameHitpoint.Value + amount));
		}
	}
}
