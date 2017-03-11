using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace End
{
	public class ViewContainerSystem : ReactiveSystem<GameEntity>
	{
		public ViewContainerSystem(Contexts contexts)
			: base(contexts.game)
		{ }

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ViewContainer, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasViewContainer && entity.hasView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				e.view.GameObject.transform.SetParent(e.viewContainer.ContainerName);
			}
		}
	}

}
