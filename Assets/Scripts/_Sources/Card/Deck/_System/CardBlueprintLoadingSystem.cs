using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;

public class CardBlueprintLoadingSystem : ReactiveSystem<CardEntity>
{
	readonly DeckSetting _setting;

	public CardBlueprintLoadingSystem(Contexts contexts, DeckSetting setting)
		: base(contexts.card)
	{
		_setting = setting;
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Card, GroupEvent.Added);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasCard;
	}

	protected Blueprint GetBlueprint(CardEntity entity)
	{
		return _setting.GetCardBlueprint(entity.card.Type);
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			e.ApplyBlueprint(GetBlueprint(e));
		}
	}
}
