using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;
using UnityEngine;
using System;

namespace Game
{
	public class LoadCardSystem : ReactiveSystem<CardEntity>
	{
		readonly DeckSetting _setting;

		public LoadCardSystem(Contexts contexts, DeckSetting setting)
			: base(contexts.card)
		{
			_setting = setting;
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameCard, GroupEvent.Added);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.hasGameCard;
		}

		protected Blueprint GetBlueprint(CardEntity entity)
		{
			return _setting.GetCardBlueprint(entity.gameCard.Type);
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				e.ApplyBlueprint(GetBlueprint(e));
			}
		}
	}
}
