using System;
using System.Collections.Generic;
using Entitas;

namespace End.Game
{
	public abstract class LocalEventSystem : ReactiveSystem<GameEntity>
	{
		public LocalEventSystem(Contexts contexts) : base(contexts.game)
		{}

		protected override void Execute(List<GameEntity> entities)
		{
			if (GameController.Instance != null && !GameUtil.IsLocalPlayerTurn) return;
			foreach(var e in entities)
			{
				Process(e);
			}
		}

		protected abstract void Process(GameEntity entity);
	}
}
