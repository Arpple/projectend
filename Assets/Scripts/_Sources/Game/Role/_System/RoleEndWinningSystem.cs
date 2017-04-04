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
			return context.CreateCollector(GameMatcher.GameDead, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameDead && entity.gameUnit.OwnerEntity.gameRole.RoleObject is RoleEnd;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.gameUnit.OwnerEntity.isGameWin = true;
			}
		}
	}
}

