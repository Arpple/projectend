using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

namespace Game.UI
{
	public class TurnNotificationSystem : ReactiveSystem<GameEventEntity>
	{
		private GameContext _context;
		private TurnNotification _noti;

		public TurnNotificationSystem(Contexts contexts, TurnNotification notification) : base(contexts.gameEvent)
		{
			_context = contexts.game;
			_noti = notification;
		}

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.GameEventEndTurn);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.isGameEventEndTurn;
		}

		protected override void Execute(List<GameEventEntity> entities)
		{
			var order = _context.gamePlayingOrder;
			var currentPlayer = order.CurrentPlayer;
			_noti.Show(order.Turn.ToString(), currentPlayer.gamePlayer.PlayerObject.name);
		}
	}
}

