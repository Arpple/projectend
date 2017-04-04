﻿using UnityEngine;
using Entitas;
using System.Linq;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class LocalCharacterHpBarSystem : ReactiveSystem<GameEntity>
	{
		private readonly HpBar _hpBar;

		public LocalCharacterHpBarSystem(Contexts contexts, HpBar hpBar) : base(contexts.game)
		{
			_hpBar = hpBar;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Hitpoint);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasHitpoint && entity.unit.OwnerEntity.isLocalPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				_hpBar.UpdateHp(e.hitpoint.Value);
			}
		}
	}
}
