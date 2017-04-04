using System;
using System.Collections.Generic;
using Entitas;

namespace Game
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
			return context.CreateCollector(GameMatcher.GameAbility, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameAbility
				&& entity.gameAbility.AbilityClassName != ""
				&& entity.gameAbility.Ability == null;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.gameAbility.Ability = _ability.Get(e.gameAbility.AbilityClassName, (name)
					=> (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name));
			}
		}
	}

}
