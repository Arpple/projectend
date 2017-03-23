using System;
using System.Collections.Generic;
using Entitas;

namespace End.Game
{
    public abstract class GameEventSystem : ReactiveSystem<GameEventEntity>, ICleanupSystem
    {
		protected readonly Contexts _contexts;
		protected List<GameEventEntity> _processed;

		public GameEventSystem(Contexts contexts)
			: base(contexts.gameEvent)
		{
			_contexts = contexts;
			_processed = new List<GameEventEntity>();
		}

		public void Cleanup()
		{
			foreach(var p in _processed)
			{
				_contexts.gameEvent.DestroyEntity(p);
			}

			_processed.Clear();
		}

		protected override void Execute(List<GameEventEntity> entities)
		{
			foreach(var e in entities)
			{
				Process(e);
				_processed.Add(e);
			}
		}

		protected abstract void Process(GameEventEntity entity);
	}

}
