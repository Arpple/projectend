using System.Collections.Generic;
using Entitas;

public class LocalPlayerStartGameFocusSystem : GameReactiveSystem
{
	UnitContext _unitContext;

	public LocalPlayerStartGameFocusSystem(Contexts contexts) : base(contexts)
	{
		_unitContext = contexts.unit;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound && entity.round.Count == 1;		
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			CameraController.Focus(_unitContext.localEntity);
		}
	}
}
