using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Offline
{
	public class LocalFlagPassingSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private SystemController _syscon;

		public LocalFlagPassingSystem(Contexts contexts, SystemController syscon) : base(contexts.game)
		{
			_context = contexts.game;
			_syscon = syscon;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.RoundIndex);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasRoundIndex;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			if(_syscon.AutoPassLocalFlag)
			{
				foreach (var e in entities)
				{
					RemoveOldFlag();
					SetNewFlag(e);
				}
			}
		}

		private void RemoveOldFlag()
		{
			if(_context.isLocal)
				_context.localEntity.isLocal = false;
		}

		private void SetNewFlag(GameEntity e)
		{
			_context.playingOrder.PlayerOrder[e.roundIndex.Index].isLocal = true;
		}
	}
}
