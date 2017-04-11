using System.Collections.Generic;
using Entitas;

public class BoxCardRenderingSystem : ReactiveSystem<CardEntity>
{
	public BoxCardRenderingSystem(Contexts contexts) : base(contexts.card)
	{
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.InBox, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasOwner;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			if (e.hasInBox)
			{
				e.owner.Entity.playerBox.BoxObject.AddCard(e.view.GameObject, e.inBox.Index);
			}
			else
			{
				e.owner.Entity.playerDeck.PlayerDeckObject.AddCard(e.view.GameObject);
			}
		}
	}
}