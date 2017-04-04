using Entitas;
using System.Collections.Generic;

namespace Game
{
	public class ViewContainerSystem : ReactiveSystem<GameEntity>
	{
		public ViewContainerSystem(Contexts contexts)
			: base(contexts.game)
		{ }

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameViewContainer, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameViewContainer && entity.hasGameView;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				e.gameView.GameObject.transform.SetParent(e.gameViewContainer.ContainerName);
			}
		}
	}

}
