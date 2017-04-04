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
			return context.GetEntities(GameMatcher.GameSkillCard)
				.Where(e => e.gamePlayerCard.OwnerEntity == playerEntity)
				.ToArray();
		}

		public static GameEntity[] GetPlayerSkills<T>(this GameContext context, GameEntity playerEntity)
		{
			return GetPlayerSkills(context, playerEntity)
				.Where(e => e.gameAbility.Ability is T)
				.ToArray();
		}
	}
}
