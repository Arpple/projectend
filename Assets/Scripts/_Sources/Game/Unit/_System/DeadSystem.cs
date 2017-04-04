using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

namespace Game
{
	public class DeadSystem : ReactiveSystem<GameEntity>
	{
		//private readonly GameContext _context;

		public DeadSystem(Contexts contexts) : base(contexts.game)
		{
			//_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameHitpoint, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			Assert.IsFalse(entity.gameHitpoint.Value < 0);

			return entity.gameHitpoint.Value == 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.isGameDead = true;
			}
		}
	}
}
