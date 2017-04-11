using System.Collections.Generic;
using Entitas;

public class RoundEndPlayingOrderReOrderingSystem : ReactiveSystem<GameEntity>
{
	private GameContext _context;

	public RoundEndPlayingOrderReOrderingSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound && entity.round.Count > 1;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			_context.playingOrder.ReOrder();
		}
	}
}
