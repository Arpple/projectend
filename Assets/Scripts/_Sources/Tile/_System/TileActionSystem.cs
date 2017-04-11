using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
public class TileActionSystem : ReactiveSystem<TileEntity>
{
	public TileActionSystem(Contexts contexts) : base(contexts.tile)
	{
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.TileAction, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(TileEntity entity)
	{
		return true;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach (var e in entities)
		{
			if (e.hasTileAction)
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
		controller.TileAction = tileEntity.tileAction.OnSelected;
	}

	private void RemoveActionFromController(TileEntity tileEntity)
	{
		var controller = GetController(tileEntity);
		controller.TileAction = null;
	}
}
