using System.Collections.Generic;
using Entitas;

public class LocalPlayerDeckRenderingSystem : ReactiveSystem<GameEntity>
{
	public LocalPlayerDeckRenderingSystem(Contexts contexts) : base(contexts.game)
	{
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Local, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasPlayerDeck;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			e.playerDeck.PlayerDeckObject.gameObject.SetActive(e.isLocal);
		}
	}
}