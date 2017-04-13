using System;
using System.Collections.Generic;
using Entitas;

public class TileResourceChargeSetupSystem : ReactiveSystem<TileEntity>
{
	private TileContext _context;
	private WeigthRandomizer<int> _chargeRandomizer;

	public TileResourceChargeSetupSystem(Contexts contexts, List<int> chargeWeigthList) : base(contexts.tile)
	{
		_context = contexts.tile;
		CreateRandomizer(chargeWeigthList);
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.Resource);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasResource && !entity.hasCharge;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach(var tile in _context.GetEntities(TileMatcher.Resource))
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