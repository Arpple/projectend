using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;
using System;

namespace Game
{
	public class GamePlayingOrderSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		readonly GameContext _context;

		public GamePlayingOrderSystem(Contexts contexts) : base(contexts.game)
		{
			Debug.Log("create order");
			_context = contexts.game;
		}

		public void Initialize()
		{
			var players = _context.GetEntities(GameMatcher.GamePlayer);

			_context.SetGamePlayingOrder(players.OrderBy(p => p.gamePlayer.PlayerId).ToList());
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameRound);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameRound && entity.gameRound.Count > 1;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			Debug.Log("order execute");
			foreach(var e in entities)
			{
				_context.gamePlayingOrder.ReOrder();
			}
		}
	}
}
