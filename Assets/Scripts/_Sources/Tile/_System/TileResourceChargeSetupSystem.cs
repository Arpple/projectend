using System.Collections.Generic;
using Entitas;

public class TileResourceChargeSetupSystem : ReactiveSystem<TileEntity>
{
	private WeigthRandomizer<int> _chargeRandomizer;

	public TileResourceChargeSetupSystem(Contexts contexts, List<int> chargeWeigthList) : base(contexts.tile)
	{
		CreateRandomizer(chargeWeigthList);
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.TileResource);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasTileResource && !entity.hasCharge;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach(var tile in entities)
		{
			tile.AddCharge(GetRandomCharge());
		}
	}

	private void CreateRandomizer(List<int> chargeWeigthList)
	{
		_chargeRandomizer = new WeigthRandomizer<int>();
		chargeWeigthList.Count.Loop(i =>
			_chargeRandomizer.AddItem(i + 1, chargeWeigthList[i])
		);
	}

	private int GetRandomCharge()
	{
		return _chargeRandomizer.GetRandomItem();
	}
}