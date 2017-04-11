using System.Collections.Generic;
using Entitas;

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
		return context.CreateCollector(CardMatcher.AbilityResources, GroupEvent.Added);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasAbilityResources
			&& entity.abilityResources.AbilityClassName != "";
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			e.AddAbility
			(
				_ability.Get
				(
					e.abilityResources.AbilityClassName,
					(name) => (Ability)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(name)
				)
			);
			_loaded.Add(e);
		}
	}

	public void Cleanup()
	{
		if (_loaded.Count > 0)
		{
			foreach (var e in _loaded)
			{
				e.RemoveAbilityResources();
			}

			_loaded.Clear();
		}
	}
}