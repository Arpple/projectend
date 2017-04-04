using System.Collections.Generic;
using Entitas;

namespace Game.UI
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
			return context.CreateCollector(GameMatcher.GameDeckCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameDeckCard && !entity.hasGamePlayerCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				_shareDeck.AddCard(e.gameView.GameObject);
			}
		}
	}

}
