using System.Linq;
using Entitas;

public static class SkillCardExtension
{
	public static CardEntity[] GetPlayerSkills(this CardContext context, GameEntity playerEntity)
	{
		return context.GetEntities(CardMatcher.SkillCard)
			.Where(e => e.owner.Entity == playerEntity)
			.ToArray();
	}

	public static CardEntity[] GetPlayerSkills<T>(this CardContext context, GameEntity playerEntity)
	{
		return GetPlayerSkills(context, playerEntity)
			.Where(e => e.ability.Ability is T)
			.ToArray();
	}
}