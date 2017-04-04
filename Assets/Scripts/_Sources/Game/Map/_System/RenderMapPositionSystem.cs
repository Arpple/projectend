using System.Collections.Generic;
using Entitas;

namespace Game
{
	public class RenderMapPositionSystem : ReactiveSystem<GameEntity>
	{

		public RenderMapPositionSystem(Contexts contexts)
			: base(contexts.game)
		{
		}

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
				var transform = e.gameView.GameObject.transform;
				transform.position = e.gameMapPosition.GetWorldPosition();
			}
		}
	}
}

