using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
	public class UnitPositionRenderingSystem : ReactiveSystem<UnitEntity>
	{

		public UnitPositionRenderingSystem(Contexts contexts): base(contexts.unit)
		{}

		protected override Collector<UnitEntity> GetTrigger (IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameMapPosition, GroupEvent.Added);
		}

		protected override bool Filter (UnitEntity entity)
		{
			return entity.hasGameMapPosition && entity.hasGameView;
		}

		protected override void Execute (List<UnitEntity> entities)
		{
			foreach(var e in entities)
			{
				var transform = e.gameView.GameObject.transform;
				transform.position = e.gameMapPosition.GetWorldPosition();
			}
		}
	}

	public class TilePositionRenderingSystem : ReactiveSystem<TileEntity>
	{

		public TilePositionRenderingSystem(Contexts contexts) : base(contexts.tile)
		{ }

		protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
		{
			return context.CreateCollector(TileMatcher.GameMapPosition, GroupEvent.Added);
		}

		protected override bool Filter(TileEntity entity)
		{
			return entity.hasGameMapPosition && entity.hasGameView;
		}

		protected override void Execute(List<TileEntity> entities)
		{
			foreach (var e in entities)
			{
				var transform = e.gameView.GameObject.transform;
				transform.position = e.gameMapPosition.GetWorldPosition();
			}
		}
	}
}

