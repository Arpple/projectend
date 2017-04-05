using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
	public class UnitPositionSystem : ReactiveSystem<GameEntity>
	{

		public UnitPositionSystem(Contexts contexts): base(contexts.game)
		{}

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameMapPosition, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasGameMapPosition && entity.hasGameView;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				Debug.Log("TEst");
				var transform = e.gameView.GameObject.transform;
				transform.position = e.gameMapPosition.GetWorldPosition();
			}
		}
	}

	public class TilePositionSystem : ReactiveSystem<TileEntity>
	{

		public TilePositionSystem(Contexts contexts) : base(contexts.tile)
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

