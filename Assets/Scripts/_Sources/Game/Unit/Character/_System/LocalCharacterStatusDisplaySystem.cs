using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using End.Game.UI;
using Entitas;
using System;

namespace End.Game
{
	public class LocalCharacterStatusSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly PlayerStatusPanel _ui;

		public LocalCharacterStatusSystem(Contexts contexts, PlayerStatusPanel ui) : base(contexts.game)
		{
			_ui = ui;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.UnitStatus, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasUnitStatus && entity.unit.OwnerEntity.isLocalPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var entity in entities)
			{
				_ui.UpdateUnitStatus(entity.unitStatus);
			}
		}
	}

}
