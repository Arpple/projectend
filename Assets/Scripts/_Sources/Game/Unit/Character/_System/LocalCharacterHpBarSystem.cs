using UnityEngine;
using Entitas;
using System.Linq;
using System.Collections.Generic;

namespace Game.UI
{
	public class LocalCharacterHpBarSystem : ReactiveSystem<UnitEntity>
	{
		private readonly HpBar _hpBar;

		public LocalCharacterHpBarSystem(Contexts contexts, HpBar hpBar) : base(contexts.unit)
		{
			_hpBar = hpBar;
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameHitpoint);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.hasGameHitpoint && entity.gameOwner.Entity.isGameLocalPlayer;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach(var e in entities)
			{
				_hpBar.UpdateHp(e.gameHitpoint.Value);
			}
		}
	}
}

