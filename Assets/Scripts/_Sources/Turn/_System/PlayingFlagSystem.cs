using System.Collections.Generic;
using Entitas;

public class PlayingFlagSystem : ReactiveSystem<GameEntity>
{
	private GameContext _context;

	public PlayingFlagSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.RoundIndex);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRoundIndex;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			RemoveOldFlag();
			SetNewFlag(e);
		}
	}

	private void RemoveOldFlag()
	{
		if (_context.isPlaying)
		{
			_context.playingEntity.isPlaying = false;
		}
	}

	private void SetNewFlag(GameEntity e)
	{
		var player = _context.playingOrder.PlayerOrder[e.roundIndex.Index];
		player.isPlaying = true;
	}
}