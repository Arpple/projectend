using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;

namespace End
{
	public abstract class LoadUnitSystem : ReactiveSystem<GameEntity>
	{
		protected GameContext _context;

		public LoadUnitSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
		}

		protected abstract Blueprint GetUnitBlueprint(GameEntity unitEntity);

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.ApplyBlueprint(GetUnitBlueprint(e));
			}
		}
	}
}

