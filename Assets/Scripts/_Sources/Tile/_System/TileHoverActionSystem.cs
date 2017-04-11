using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

public class TileHoverActionSystem : ReactiveSystem<TileEntity>, ITearDownSystem
{
	readonly TileContext _context;

	public TileHoverActionSystem(Contexts contexts)
		: base(contexts.tile)
	{
		_context = contexts.tile;
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.TileAction, GroupEvent.Added);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasTileAction;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach (var e in entities)
		{
			Assert.IsTrue(e.hasView);
			Assert.IsTrue(e.hasTile);

			var tileCon = e.view.GameObject.GetComponent<TileController>();
			Assert.IsNotNull(tileCon);

			var tileHoverAction = e.tileHoverAction;
			tileCon.MouseEnterAction = () => tileHoverAction.HoverAction(tileHoverAction.Source, tileHoverAction.Target);
		}
	}

	public void TearDown()
	{
		foreach (var e in _context.GetEntities(TileMatcher.Tile))
		{
			var tileCon = e.view.GameObject.GetComponent<TileController>();
			Assert.IsNotNull(tileCon);

			// tileCon.ClickAction = null;
		}
	}
}
