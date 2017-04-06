using System;
using System.Collections.Generic;
using Entitas;

namespace Game
{
	public class AbilityResourceLoadingSystem : ReactiveSystem<CardEntity>, ICleanupSystem
	{
		readonly CacheList<string, Ability> _ability;
		private List<CardEntity> _loaded;

		public AbilityResourceLoadingSystem(Contexts contexts)
			: base(contexts.card)
		{
			_ability = new CacheList<string, Ability>();
			_loaded = new List<CardEntity>();
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameAbilityResources, GroupEvent.Added);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.hasGameAbilityResources
				&& entity.gameAbilityResources.AbilityClassName != "";
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				e.AddGameAbility
				(
					_ability.Get
					(
						e.gameAbilityResources.AbilityClassName, 
						(name) => (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name)
					)
				);
				_loaded.Add(e);
			}
		}

		public void Cleanup()
		{
			if(_loaded.Count > 0)
			{
				foreach (var e in _loaded)
				{
					e.RemoveGameAbilityResources();
				}

				_loaded.Clear();
			}
		}			
	}
}
