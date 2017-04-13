using System.Collections.Generic;
using Entitas;

public class TileResourceChargeSetupSystem : IInitializeSystem
{
	private TileContext _context;
	private WeigthRandomizer<int> _chargeRandomizer;

	public TileResourceChargeSetupSystem(Contexts contexts, List<int> chargeWeigthList)
	{
		_context = contexts.tile;
		CreateRandomizer(chargeWeigthList);
	}

	public void Initialize()
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