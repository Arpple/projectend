using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class WinSystem : ReactiveSystem<GameEntity>
{
	public WinSystem(Contexts contexts) : base(contexts.game)
	{ }

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Winner, GroupEvent.Added);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isWinner;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		Debug.Log("Game End");
		foreach (var e in entities)
		{
			var player = e.player.PlayerObject;
			Debug.Log(player.GetName() + "(" + player.GetId() + ") win");
		}
	}
}