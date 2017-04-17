using System.Collections.Generic;
using Entitas;

public class ShareDeckRenderingSystem : ReactiveSystem<CardEntity>
{
	private readonly CardContainer _shareDeck;

	public ShareDeckRenderingSystem(Contexts contexts, CardContainer shareDeck)
		: base(contexts.card)
	{
		_shareDeck = shareDeck;
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return new Collector<CardEntity>(
			new[]{
					context.GetGroup(CardMatcher.DeckCard),
					context.GetGroup(CardMatcher.Owner)
				},
			new[]{
					GroupEvent.Added,
					GroupEvent.Removed
			}
		);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasDeckCard && !entity.hasOwner;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			_shareDeck.AddCard(e.view.GameObject);
		}
	}
}