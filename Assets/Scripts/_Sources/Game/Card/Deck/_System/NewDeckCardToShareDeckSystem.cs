using System.Collections.Generic;
using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class NewDeckCardToShareDeckSystem : ReactiveSystem<GameEntity>
	{
		private readonly PlayerDeck _shareDeck;

		public NewDeckCardToShareDeckSystem(Contexts contexts, PlayerDeck shareDeck)
			: base(contexts.game)
		{
			_shareDeck = shareDeck;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Card, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return !entity.hasPlayerCard;
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
