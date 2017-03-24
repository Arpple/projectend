using System.Collections.Generic;
using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class RenderMiddleDeckSystem : ReactiveSystem<GameEntity>
	{
		private readonly CardContainer _cardContainer;

		public RenderMiddleDeckSystem(Contexts contexts, CardContainer cardContainer)
			: base(contexts.game)
		{
			_cardContainer = cardContainer;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayerCard && entity.playerCard.CurrentOwnerId == 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.view.GameObject.transform.SetParent(_cardContainer.PlayerDecks[0].transform, false);
			}
		}
	}

}
