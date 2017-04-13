using System.Collections.Generic;
using Entitas;

public class TileResourceSpriteUpdateSystem : ReactiveSystem<TileEntity>
{
	public TileResourceSpriteUpdateSystem(Contexts contexts) : base(contexts.tile)
	{

	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.Charge);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasCharge;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach(var e in entities)
		{
			if(IsChargeEmpty(e))
			{
				SwitchToEmptyChargeSprite(e);
			}
			else
			{
				SwitchToOriginalSprite(e);
			}
		}
	}

	private bool IsChargeEmpty(TileEntity entity)
	{
		return entity.charge.Count == 0;
	}

	private void SwitchToEmptyChargeSprite(TileEntity entity)
	{
		entity.ReplaceSprite(entity.resource.EmptySprite);
	}

	private void SwitchToOriginalSprite(TileEntity entity)
	{
		entity.ReplaceSprite(entity.resource.GetOriginalSprite());
	}
}