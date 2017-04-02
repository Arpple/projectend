using System.Linq;
using System.Collections.Generic;
using Entitas;
using End.Game.UI;
using UnityEngine.Assertions;

namespace End.Game
{
	public class PlayerBoxCardRemoveSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private CacheList<GameEntity, PlayerDeck> _playerDeckCache;

		public PlayerBoxCardRemoveSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_playerDeckCache = new CacheList<GameEntity, PlayerDeck>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.InBox, GroupEvent.Removed);
		}

		protected override bool Filter(GameEntity entity)
		{
			return !entity.hasInBox && entity.hasPlayerCard; //not in box but still in hand
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				var deck = _playerDeckCache.Get(e.playerCard.OwnerEntity, (playerEntity) =>
					_context.GetEntities(GameMatcher.PlayerDeck)
						.Where(p => p == playerEntity)
						.First()
						.playerDeck.PlayerDeckObject
				);

				deck.AddCard(e.view.GameObject);
			}
		}
	}

}
