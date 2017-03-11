﻿using System.Collections.Generic;
using Entitas;

namespace End.Game
{
	public class RenderMapPositionSystem : ReactiveSystem<GameEntity>
	{

		public RenderMapPositionSystem(Contexts contexts)
			: base(contexts.game)
		{
		}

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.MapPosition, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasMapPosition && entity.hasView;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				var transform = e.view.GameObject.transform;
				transform.position = e.mapPosition.GetWorldPosition();
			}
		}
	}
}

