using System.Linq;
using System.Collections.Generic;
using Entitas;
using Game.UI;

namespace Game
{
	public class RenderPlayerDeckSystem : ReactiveSystem<CardEntity>
	{
		private GameContext _gameContext;
		private CacheList<GameEntity, CardContainer> _playerDeckCache;

		public RenderPlayerDeckSystem(Contexts contexts)
			: base(contexts.card)
		{
			_gameContext = contexts.game;
			_playerDeckCache = new CacheList<GameEntity, CardContainer>();
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameOwner, GroupEvent.Added);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.hasGameOwner && entity.isGameDeckCard;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				var deck = _playerDeckCache.Get(e.gameOwner.Entity, (playerEntity) =>
					_gameContext.GetEntities(GameMatcher.GamePlayerDeck)
						.Where(p => p == playerEntity)
						.First()
						.gamePlayerDeck.PlayerDeckObject
				);

				deck.AddCard(e.gameView.GameObject);
			}
		}
	}

}
