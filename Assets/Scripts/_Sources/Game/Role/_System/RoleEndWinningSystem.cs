using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game
{
	public class RoleEndWinningSystem : ReactiveSystem<UnitEntity>
	{
		public RoleEndWinningSystem(Contexts contexts) : base(contexts.unit)
		{

		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameDead, GroupEvent.Added);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.isGameDead && entity.gameUnit.OwnerEntity.gameRole.RoleObject is RoleEnd;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach(var e in entities)
			{
				e.gameUnit.OwnerEntity.isGameWin = true;
			}
		}
	}
}

