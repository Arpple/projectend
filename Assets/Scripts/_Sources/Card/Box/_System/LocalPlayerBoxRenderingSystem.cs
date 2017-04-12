using System.Collections.Generic;
using Entitas;

public class LocalPlayerBoxRenderingSystem : ReactiveSystem<GameEntity>
{
	public LocalPlayerBoxRenderingSystem(Contexts contexts) : base(contexts.game)
	{
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Local, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasPlayerBox;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			e.playerBox.BoxObject.gameObject.SetActive(e.isLocal);
		}
	}
}