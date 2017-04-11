using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;


public abstract class BlueprintLoadingSystem : ReactiveSystem<GameEntity>
{
	protected GameContext _context;

	public BlueprintLoadingSystem(Contexts contexts)
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