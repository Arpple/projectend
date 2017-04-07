using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

namespace Game.UI
{
	public class TurnNotificationSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private TurnNotification _noti;

		public TurnNotificationSystem(Contexts contexts, TurnNotification notification) : base(contexts.game)
		{
			_context = contexts.game;
			_noti = notification;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameTurn);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameTurn;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var e = entities[entities.Count - 1];
			_noti.Show(e.gameTurn.Count.ToString(), _context.gamePlayingEntity.gamePlayer.PlayerObject.PlayerName.ToString());
		}
	}
}

