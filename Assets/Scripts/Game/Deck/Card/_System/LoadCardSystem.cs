using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;
using UnityEngine;

namespace End.Game
{
	public class LoadCardSystem : LoadBlueprintSystem
	{
		readonly CardSetting _setting;

		private CacheList<string, Ability> _ability;

		public LoadCardSystem(Contexts contexts, CardSetting setting)
			: base(contexts)
		{
			_setting = setting;
			_ability = new CacheList<string, Ability>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Card);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCard;
		}

		protected override Blueprint GetBlueprint(GameEntity entity)
		{
			return _setting.GetCardBlueprint(entity.card.Type);
		}

		protected override void Execute(List<GameEntity> entities)
		{
			base.Execute(entities);
			foreach (var e in entities)
			{
				if(e.hasAbility)
				{
					var ability = _ability.Get(e.ability.AbilityClassName, (name)
						=> (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name));
					e.ability.Ability = ability;
				}
			}
		}
	}
}
