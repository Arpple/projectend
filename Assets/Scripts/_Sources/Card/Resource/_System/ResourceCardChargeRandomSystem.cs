using System.Collections.Generic;
using Entitas;

public class ResourceCardChargeRandomSystem : CardReactiveSystem
{
	private ResourceCardSetting _setting;
	private WeigthRandomizer<int> _chargeRandomizer;

	public ResourceCardChargeRandomSystem(Contexts contexts, ResourceCardSetting setting) : base(contexts)
	{
		_setting = setting;
		InitChargeRandom();
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.ResourceCard);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasResourceCard && !entity.hasCharge;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach(var e in entities)
		{
			var charge = _chargeRandomizer.GetRandomItem();
			e.AddCharge(charge);
		}
	}

	private void InitChargeRandom()
	{
		_chargeRandomizer = new WeigthRandomizer<int>();

		var weigthList = _setting.CardChargeWeigth;
		weigthList.Count.Loop(i => _chargeRandomizer.AddItem(i + 1, weigthList[i]));
	}
}