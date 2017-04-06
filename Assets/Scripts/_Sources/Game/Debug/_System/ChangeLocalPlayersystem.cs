using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Offline
{
	public class LocalFlagPassingSystem : ReactiveSystem<GameEventEntity>
	{
		private GameContext _context;

		public LocalFlagPassingSystem(Contexts contexts) : base(contexts.gameEvent)
		{
			_context = contexts.game;
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
			foreach(var e in entities)
			{
				_context.gameLocalEntity.isGameLocal = false;
				_context.gamePlayingOrder.CurrentPlayer.isGameLocal = true;
			}
		}
	}
}
