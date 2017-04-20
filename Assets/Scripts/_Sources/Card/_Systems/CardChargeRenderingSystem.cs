using System.Collections.Generic;
using Entitas;

public class CardChargeRenderingSystem : CardReactiveSystem
{
	public CardChargeRenderingSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Charge);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasCharge && entity.hasView;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach(var e in entities)
		{
			var card = e.view.GameObject.GetComponent<CardObject>();
			card.SetCharge(e.charge.Count);
		}
	}
}