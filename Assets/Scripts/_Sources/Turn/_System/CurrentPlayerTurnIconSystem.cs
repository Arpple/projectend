using System.Collections.Generic;
using Entitas;

public class CurrentPlayerTurnIconSystem : GameReactiveSystem
{
	public CurrentPlayerTurnIconSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasTurnNode;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			if(e.isPlaying)
			{
				e.turnNode.Object.SetAsCurrentTurn();
			}
			else
			{
				e.turnNode.Object.RemoveCurrentTurn();
			}
		}
	}
}