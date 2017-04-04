using UnityEngine;
using Entitas;
using System.Linq;
using System.Collections.Generic;

namespace Game.UI
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
			return context.CreateCollector(GameMatcher.GameHitpoint);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameHitpoint && entity.gameUnit.OwnerEntity.isGameLocalPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				_hpBar.UpdateHp(e.gameHitpoint.Value);
			}
		}
	}
}

