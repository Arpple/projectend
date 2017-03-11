using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;

namespace End
{
	public abstract class LoadBlueprintSystem : ReactiveSystem<GameEntity>
	{
		protected GameContext _context;

		public LoadBlueprintSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
		}

		protected abstract Blueprint GetBlueprint(GameEntity entity);

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				e.ApplyBlueprint(GetBlueprint(e));
			}
		}
	}
}
