using UnityEngine;
using Entitas;
using System.Collections.Generic;

namespace Game.UI
{
	public class LocalPlayerBoxSystem : ReactiveSystem<GameEntity>
	{
		public LocalPlayerBoxSystem(Contexts contexts) : base(contexts.game)
		{
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameLocal, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGamePlayerBox;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				e.gamePlayerBox.BoxObject.gameObject.SetActive(e.isGameLocal);
			}
		}
	}
}
