using System.Collections.Generic;
using Entitas;

namespace End.Game.UI
{
	public class NewDeckCardToShareDeckSystem : ReactiveSystem<GameEntity>
	{
		private readonly CardContainer _shareDeck;

		public NewDeckCardToShareDeckSystem(Contexts contexts, CardContainer shareDeck)
			: base(contexts.game)
		{
			_shareDeck = shareDeck;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.DeckCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isDeckCard && !entity.hasPlayerCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				_shareDeck.AddCard(e.view.GameObject);
			}
		}
	}

}
