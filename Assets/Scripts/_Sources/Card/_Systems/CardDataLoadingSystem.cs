using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

public class CardDataLoadingSystem : DataLoadingSystem<CardEntity, CardData>
{
	private CardSetting _setting;

	public CardDataLoadingSystem(Contexts contexts, CardSetting setting) : base(contexts.card)
	{
		_setting = setting;
	}

	protected override IEntityFactory<CardEntity, CardData> CreateEntityFactory(IContext<CardEntity> context)
	{
		return new CardEntityFactory(context);
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Card);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasCard;
	}

	protected override CardData GetData(CardEntity entity)
	{
		return _setting.GetCardData(entity.card.Type);
	}
}