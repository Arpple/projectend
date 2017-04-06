using System.Linq;
using System.Collections.Generic;
using Entitas;
using Game.UI;

namespace Game
{
	public class RenderPlayerDeckSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private CacheList<GameEntity, CardContainer> _playerDeckCache;

		public RenderPlayerDeckSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_playerDeckCache = new CacheList<GameEntity, CardContainer>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameOwner, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameOwner && entity.isGameDeckCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				var deck = _playerDeckCache.Get(e.gameOwner.Entity, (playerEntity) =>
					_context.GetEntities(GameMatcher.GamePlayerDeck)
						.Where(p => p == playerEntity)
						.First()
						.gamePlayerDeck.PlayerDeckObject
				);

				deck.AddCard(e.gameView.GameObject);
			}
		}
	}

}
