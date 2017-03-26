using System;
using System.Collections.Generic;
using Entitas;

namespace End.Game
{
	public class LoadAbilitySystem : ReactiveSystem<GameEntity>
	{
		readonly CacheList<string, Ability> _ability;

		public LoadAbilitySystem(Contexts contexts)
			: base(contexts.game)
		{
			_ability = new CacheList<string, Ability>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Ability, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasAbility
				&& entity.ability.AbilityClassName != ""
				&& entity.ability.Ability == null;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.ability.Ability = _ability.Get(e.ability.AbilityClassName, (name)
					=> (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name));
			}
		}
	}

}
