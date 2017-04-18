using System.Collections.Generic;
using System.Linq;
using Entitas;

public class EventHpDepleteSystem : ReactiveSystem<UnitEntity>
{
	private readonly CardContext _cardContext;

	public EventHpDepleteSystem(Contexts contexts) : base(contexts.unit)
	{
		_cardContext = contexts.card;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Hitpoint, GroupEvent.Added);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hitpoint.Value == 0 && entity.owner.Entity.hasPlayerBox;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var e in entities)
		{
			UseBoxReviveCard(e);
			UseBoxOnDeadCard(e);
		}
	}

	private void UseBoxReviveCard(UnitEntity deadEntity)
	{
		var card = _cardContext.GetPlayerBoxCards<IReviveAbility>(deadEntity.owner.Entity)
			.OrderBy(c => c.inBox.Index)
			.FirstOrDefault();
		if (card != null)
		{
			var ability = (IReviveAbility)card.ability.Ability;
			ability.OnDead(deadEntity);
			card.MoveCardToDeck();
		}
	}

	private void UseBoxOnDeadCard(UnitEntity deadEntity)
	{
		var cards = _cardContext.GetPlayerBoxCards<IOnDeadAbility>(deadEntity.owner.Entity);

		foreach (var card in cards)
		{
			var ability = (IOnDeadAbility)card.ability.Ability;
			ability.OnDead(deadEntity);
			card.MoveCardToDeck();
		}
	}
}