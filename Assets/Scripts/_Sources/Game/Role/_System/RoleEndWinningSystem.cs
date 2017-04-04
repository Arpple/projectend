using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game
{
	public class RoleEndWinningSystem : ReactiveSystem<GameEntity>
	{
		public RoleEndWinningSystem(Contexts contexts) : base(contexts.game)
		{

		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Dead, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isDead && entity.unit.OwnerEntity.role.RoleObject is RoleEnd;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.unit.OwnerEntity.isWin = true;
			}
		}
	}
}

