using Entitas;
using System.Linq;
using UnityEngine;

namespace Game
{
	[Card]
	public class SkillCardComponent : IComponent
	{}

	public static class SkillCardExtension
	{
		public static CardEntity[] GetPlayerSkills(this CardContext context, GameEntity playerEntity)
		{
			return context.GetEntities(CardMatcher.GameSkillCard)
				.Where(e => e.gameOwner.Entity == playerEntity)
				.ToArray();
		}

		public static CardEntity[] GetPlayerSkills<T>(this CardContext context, GameEntity playerEntity)
		{
			return GetPlayerSkills(context, playerEntity)
				.Where(e => e.gameAbility.Ability is T)
				.ToArray();
		}
	}
}
