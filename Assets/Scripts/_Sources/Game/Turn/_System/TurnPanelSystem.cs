using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;

public class TurnPanelSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
	private readonly GameContext _gameContext;
	private readonly TurnPanel _turnPanel;

	public TurnPanelSystem(Contexts contexts, TurnPanel turnPanel) : base(contexts.game)
	{
		_gameContext = contexts.game;
		_turnPanel = turnPanel;
	}

	public void Initialize()
	{
		foreach (var player in _gameContext.GetEntities(GameMatcher.Player))
		{
			var turnNode = _turnPanel.CreateTurnNode();
			player.AddTurnNode(turnNode);
		}
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.PlayingOrder);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasPlayingOrder;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			var order = e.playingOrder.PlayerOrder;
			order.Count.Loop(i =>
			{
				order[i].turnNode.Object.transform.SetSiblingIndex(i);
			});

			_turnPanel.TurnNodes = order.Select(o => o.turnNode.Object).ToList();
		}
	}
}