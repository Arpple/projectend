using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
public class TileHoverActionSystem : ReactiveSystem<TileEntity>
{
	public TileHoverActionSystem(Contexts contexts) : base(contexts.tile)
	{
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.TileHoverAction, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasView;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach (var e in entities)
		{
			if (e.hasTileHoverAction)
				AddActionToController(e);
			else
				RemoveActionFromController(e);
		}
	}

	private TileController GetController(TileEntity tileEntity)
	{
		return tileEntity.view.GameObject.GetComponent<TileController>();
	}

	private void AddActionToController(TileEntity tileEntity)
	{
		var controller = GetController(tileEntity);
		controller.MouseEnterAction = tileEntity.tileHoverAction.TileHoverAction;
	}

	private void RemoveActionFromController(TileEntity tileEntity)
	{
		var controller = GetController(tileEntity);
		controller.MouseEnterAction = null;
	}
}
