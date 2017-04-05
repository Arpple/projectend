using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game
{
	public class TileActionSystem : ReactiveSystem<TileEntity>
	{
		public TileActionSystem(Contexts contexts) : base(contexts.tile)
		{
		}

		protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
		{
			return context.CreateCollector(TileMatcher.GameTileAction, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(TileEntity entity)
		{
			return true;
		}

		protected override void Execute(List<TileEntity> entities)
		{
			foreach(var e in entities)
			{
				if (e.hasGameTileAction)
					AddActionToController(e);
				else
					RemoveActionFromController(e);
			}
		}

		private TileController GetController(TileEntity tileEntity)
		{
			return tileEntity.gameView.GameObject.GetComponent<TileController>();
		}

		private void AddActionToController(TileEntity tileEntity)
		{
			var controller = GetController(tileEntity);
			controller.TileAction = tileEntity.gameTileAction.OnSelected;
		}

		private void RemoveActionFromController(TileEntity tileEntity)
		{
			var controller = GetController(tileEntity);
			controller.TileAction = null;
		}
	}

}
