using Entitas;
using System.Linq;
using UnityEngine;

namespace Game
{
	[Game]
	public class SkillCardComponent : IComponent
	{}

	public static class SkillCardExtension
	{
		public static GameEntity[] GetPlayerSkills(this GameContext context, GameEntity playerEntity)
		{
			return context.GetEntities(GameMatcher.SkillCard)
				.Where(e => e.playerCard.OwnerEntity == playerEntity)
				.ToArray();
		}

		public static GameEntity[] GetPlayerSkills<T>(this GameContext context, GameEntity playerEntity)
		{
			return GetPlayerSkills(context, playerEntity)
				.Where(e => e.ability.Ability is T)
				.ToArray();
		}
	}
}
