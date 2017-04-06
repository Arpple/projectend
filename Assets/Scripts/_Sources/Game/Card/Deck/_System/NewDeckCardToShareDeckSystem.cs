using System.Collections.Generic;
using Entitas;

namespace Game.UI
{
	public class NewDeckCardToShareDeckSystem : ReactiveSystem<CardEntity>
	{
		private readonly CardContainer _shareDeck;

		public NewDeckCardToShareDeckSystem(Contexts contexts, CardContainer shareDeck)
			: base(contexts.card)
		{
			_shareDeck = shareDeck;
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameDeckCard, GroupEvent.Added);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.isGameDeckCard && !entity.hasGameOwner;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach (var e in entities)
			{
				_shareDeck.AddCard(e.gameView.GameObject);
			}
		}
	}

}
