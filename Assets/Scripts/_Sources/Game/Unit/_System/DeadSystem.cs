using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

namespace Game
{
	public class DeadSystem : ReactiveSystem<UnitEntity>
	{
		//private readonly GameContext _context;

		public DeadSystem(Contexts contexts) : base(contexts.unit)
		{
			//_context = contexts.game;
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameHitpoint, GroupEvent.Added);
		}

		protected override bool Filter(UnitEntity entity)
		{
			Assert.IsFalse(entity.gameHitpoint.Value < 0);

			return entity.gameHitpoint.Value == 0;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach(var e in entities)
			{
				e.isGameDead = true;
			}
		}
	}
}
