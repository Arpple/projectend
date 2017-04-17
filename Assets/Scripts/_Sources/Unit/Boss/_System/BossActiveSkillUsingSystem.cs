using System.Collections.Generic;
using Entitas;

public class BossActiveSkillUsingSystem : GameReactiveSystem
{
	private CardContext _cardContext;
	private UnitContext _unitContext;

	public BossActiveSkillUsingSystem(Contexts contexts) : base(contexts)
	{
		_cardContext = contexts.card;
		_unitContext = contexts.unit;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isPlaying && entity.isBossPlayer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			var cards = _cardContext.GetPlayerSkills<SelfActiveAbility>(e);
			var unit = _unitContext.GetEntityOwnedBy(e);
			foreach(var card in cards)
			{
				var ability = card.ability.Ability as SelfActiveAbility;
				ability.OnTargetSelected(unit, unit);
			}
		}
	}
}