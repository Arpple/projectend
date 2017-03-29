﻿using System.Linq;
using System.Collections.Generic;
using Entitas;
using End.Game.UI;
using UnityEngine.Assertions;

namespace End.Game
{
	public class PlayerBoxCardRemoveSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private CacheList<int, PlayerDeck> _playerDeckCache;

		public PlayerBoxCardRemoveSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_playerDeckCache = new CacheList<int, PlayerDeck>();
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
				var deck = _playerDeckCache.Get(e.playerCard.CurrentOwnerId, (id) =>
					_context.GetEntities(GameMatcher.PlayerDeck)
						.Where(p => p.player.PlayerId == id)
						.First()
						.playerDeck.PlayerDeckObject
				);

				deck.AddCard(e.view.GameObject);
			}
		}
	}

}