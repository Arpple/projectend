using System.Collections.Generic;
using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class RenderShareDeckSystem : ReactiveSystem<GameEntity>
	{
		private readonly CardContainer _cardContainer;

		public RenderShareDeckSystem(Contexts contexts, CardContainer cardContainer)
			: base(contexts.game)
		{
			_cardContainer = cardContainer;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerDeckCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayerDeckCard && entity.playerDeckCard.CurrentOwnerId == 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				_cardContainer.PlayerDecks[0].AddCard(e.view.GameObject);
			}
		}
	}

}
