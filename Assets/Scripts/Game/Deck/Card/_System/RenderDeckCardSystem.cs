using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace End.Game
{
	public class RenderDeckCardSystem : ReactiveSystem<GameEntity>
	{
		public RenderDeckCardSystem(Contexts contexts)
			: base(contexts.game)
		{

		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayerCard && entity.playerCard.CurrentOwnerId == 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				//TODO: move this to deck
			}
		}
	}

}
