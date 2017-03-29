using System;
using System.Collections.Generic;
using Entitas;

namespace End.Game
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
			return context.CreateCollector(GameMatcher.Hitpoint, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hitpoint.HitPoint <= 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.isDead = true;
			}
		}
	}
}
