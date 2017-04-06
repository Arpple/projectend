using System;
using System.Collections.Generic;
using Entitas;

namespace Game
{
	public class LoadAbilitySystem : ReactiveSystem<CardEntity>
	{
		readonly CacheList<string, Ability> _ability;

		public LoadAbilitySystem(Contexts contexts)
			: base(contexts.card)
		{
			_ability = new CacheList<string, Ability>();
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameAbility, GroupEvent.Added);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.hasGameAbility
				&& entity.gameAbility.AbilityClassName != ""
				&& entity.gameAbility.Ability == null;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				e.gameAbility.Ability = _ability.Get(e.gameAbility.AbilityClassName, (name)
					=> (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name));
			}
		}
	}

}
