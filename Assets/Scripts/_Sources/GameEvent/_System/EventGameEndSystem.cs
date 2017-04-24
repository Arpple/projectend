using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventGameEndSystem : EventReactiveSystem
{
	private GameContext _gameContext;
	private UnityAction _gameEndAction;

	public EventGameEndSystem(Contexts contexts, UnityAction gameEndAction) : base(contexts)
	{
		_gameContext = contexts.game;
		_gameEndAction = gameEndAction;
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventEndGame);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.isEventEndGame;
	}

	protected override void Execute(List<GameEventEntity> entities)
	{
		Assert.AreEqual(1, entities.Count);

		var players = _gameContext.GetEntities(GameMatcher.Player)
			.Where(e => !e.isBossPlayer);

		foreach (var player in players)
		{
			var p = player.player.GetNetworkPlayer();
			p.MainMissionComplete = player.isMainMissionCompleted;
			p.PlayerMissionComplete = player.isPlayerMissionCompleted;
		}

		_gameEndAction();
	}
}