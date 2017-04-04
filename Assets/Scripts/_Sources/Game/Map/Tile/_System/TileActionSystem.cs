using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game
{
	public class TileActionSystem : ReactiveSystem<GameEntity>
	{
		public TileActionSystem(Contexts contexts) : base(contexts.game)
		{
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.TileAction, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				if (e.hasTileAction)
					AddActionToController(e);
				else
					RemoveActionFromController(e);
			}
		}

		private TileController GetController(GameEntity tileEntity)
		{
			return tileEntity.view.GameObject.GetComponent<TileController>();
		}

		private void AddActionToController(GameEntity tileEntity)
		{
			var controller = GetController(tileEntity);
			controller.TileAction = tileEntity.tileAction.OnSelected;
		}

		private void RemoveActionFromController(GameEntity tileEntity)
		{
			var controller = GetController(tileEntity);
			controller.TileAction = null;
		}
	}

}
