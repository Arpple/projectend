using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

public class EventGameEndSystem : EventReactiveSystem
{
	public EventGameEndSystem(Contexts contexts) : base(contexts)
	{
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

		Debug.Log("End");
	}
}