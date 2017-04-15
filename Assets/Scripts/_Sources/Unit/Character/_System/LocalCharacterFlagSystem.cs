using System.Collections.Generic;
using Entitas;

public class LocalCharacterFlagSystem : ReactiveSystem<GameEntity>
{
	private UnitContext _context;

	public LocalCharacterFlagSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.unit;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Local, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			_context.GetEntityOwnedBy(e)
				.isLocal = e.isLocal;
		}
	}
}