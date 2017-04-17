using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ResourceCardDestroySystem : ReactiveSystem<CardEntity>
{
	public ResourceCardDestroySystem(Contexts contexts) : base(contexts.card)
	{

	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Owner, GroupEvent.Removed);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasResourceCard && !entity.hasOwner;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach(var e in entities)
		{
			e.view.GameObject.Unlink();
			Object.Destroy(e.view.GameObject);
			e.Destroy();
		}
	}
}
