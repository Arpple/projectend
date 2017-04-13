using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

public class TileSpriteUpdateSystem : ReactiveSystem<TileEntity>
{
	public TileSpriteUpdateSystem(Contexts contexts) : base(contexts.tile)
	{

	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.Sprite);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasSprite && entity.hasView;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach(var e in entities)
		{
			var tileCon = e.view.GameObject.GetComponent<TileController>();
			tileCon.SetSprite(e.sprite.Sprite);
		}
	}
}
