using System;
using System.Collections.Generic;
using Entitas;

namespace End.Game
{
	public abstract class LocalEventSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;

		public LocalEventSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			if (GameController.Instance != null && _context.IsLocalPlayerTurn) return;
			foreach(var e in entities)
			{
				Process(e);
			}
		}

		protected abstract void Process(GameEntity entity);
	}
}
