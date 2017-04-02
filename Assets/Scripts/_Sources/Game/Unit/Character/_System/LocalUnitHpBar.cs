using UnityEngine;
using Entitas;
using System.Linq;
using System.Collections.Generic;
using End.Game.UI;
using System;

namespace End.Game
{
	public class LocalCharacterHpBarSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly HpBar _hpBar;

		public LocalCharacterHpBarSystem(Contexts contexts, HpBar hpBar) : base(contexts.game)
		{
			_context = contexts.game;
			_hpBar = hpBar;
		}

		public void Initialize()
		{
			var localCharacter = _context.GetEntities(GameMatcher.Character)
				.Where(c => c.unit.OwnerEntity.isLocalPlayer)
				.First();

			_hpBar.SetMaxValue(localCharacter.unitStatus.HitPoint);
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

