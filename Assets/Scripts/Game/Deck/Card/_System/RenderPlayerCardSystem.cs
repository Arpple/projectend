using System.Linq;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using End.Game.UI;

namespace End.Game
{
	public class RenderPlayerCardSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private CacheList<int, GameObject> _playerDeckCache;

		public RenderPlayerCardSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_playerDeckCache = new CacheList<int, GameObject>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayerCard && entity.playerCard.CurrentOwnerId > 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				var deck = _playerDeckCache.Get(e.playerCard.CurrentOwnerId, (id) =>
					_context.GetEntities(GameMatcher.PlayerDeck)
						.Where(p => p.player.PlayerId == id)
						.First()
						.playerDeck.PlayerDeckObject
				);

				e.view.GameObject.transform.SetParent(deck.transform, false);
			}
		}
	}

}
