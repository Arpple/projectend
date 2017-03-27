﻿using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;
using UnityEngine;

namespace End.Game
{
	public class LoadDeckCardSystem : LoadBlueprintSystem
	{
		readonly CardSetting _setting;

		public LoadDeckCardSystem(Contexts contexts, CardSetting setting)
			: base(contexts)
		{
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Card, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCard;
		}

		protected override Blueprint GetBlueprint(GameEntity entity)
		{
			return _setting.GetCardBlueprint(entity.card.Type);
		}
	}
}