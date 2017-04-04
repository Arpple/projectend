using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;
using UnityEngine;

namespace Game
{
	public class LoadCardSystem : LoadBlueprintSystem
	{
		readonly DeckSetting _setting;

		public LoadCardSystem(Contexts contexts, DeckSetting setting)
			: base(contexts)
		{
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameCard;
		}

		protected override Blueprint GetBlueprint(GameEntity entity)
		{
			return _setting.GetCardBlueprint(entity.gameCard.Type);
		}
	}
}
