using System.Collections.Generic;
using Entitas;

public class TurnNodeCreatingSystem : GameReactiveSystem
{
	private TurnPanel _turnPanel;
	private UnitContext _unitContext;

	public TurnNodeCreatingSystem(Contexts contexts, TurnPanel turnPanel) : base(contexts)
	{
		_turnPanel = turnPanel;
		_unitContext = contexts.unit;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Player);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasPlayer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			var turnNode = _turnPanel.CreateTurnNode();
			e.AddTurnNode(turnNode);
			turnNode.SetCharacter(_unitContext.GetEntityOwnedBy(e));
		}
	}
}