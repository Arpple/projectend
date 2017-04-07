using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game
{
	public class PlayingFlagSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;

		public PlayingFlagSystem(Contexts contexts) : base(contexts.game)
		{
			Debug.Log("create flag");
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
			if(_context.isGamePlaying)
			{
				_context.gamePlayingEntity.isGamePlaying = false;
			}
		}

		private void SetNewFlag(GameEntity e)
		{
			var player = _context.gamePlayingOrder.PlayerOrder[e.gameRoundIndex.Index];
			player.isGamePlaying = true;
		}
	}
}
