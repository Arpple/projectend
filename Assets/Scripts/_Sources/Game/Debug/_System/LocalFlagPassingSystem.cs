using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Offline
{
	public class LocalFlagPassingSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;

		public LocalFlagPassingSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameRoundIndex);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameRoundIndex;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				RemoveOldFlag();
				SetNewFlag(e);
			}
		}

		private void RemoveOldFlag()
		{
			if(_context.isGameLocal)
				_context.gameLocalEntity.isGameLocal = false;
		}

		private void SetNewFlag(GameEntity e)
		{
			_context.gamePlayingOrder.PlayerOrder[e.gameRoundIndex.Index].isGameLocal = true;
		}
	}
}
