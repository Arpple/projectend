using Entitas;

public class EventEndTurnSystem : EventSystem
{
	private GameContext _gameContext;

	public EventEndTurnSystem(Contexts contexts) : base(contexts)
	{
		_gameContext = contexts.game;
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventEndTurn, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.isEventEndTurn;
	}

	protected override void Process(GameEventEntity entity)
	{
		var cycler = new TurnRoundCycler(_gameContext);
		cycler.Cycle();
	}

	private class TurnRoundCycler
	{
		private GameContext _context;
		private int _currentRoundIndex;
		private int _currentRoundCount;
		private int _currentTurn;

		public TurnRoundCycler(GameContext context)
		{
			_context = context;
			_currentRoundCount = _context.round.Count;
			_currentRoundIndex = _context.roundIndex.Index;
			_currentTurn = _context.turn.Count;
		}

		public void Cycle()
		{
			if (IsRoundEnd())
			{
				EndRound();
			}
			else
			{
				EndTurn();
			}
			_context.ReplaceTurn(_currentTurn + 1);
		}

		private bool IsRoundEnd()
		{
			var playerCount = _context.playingOrder.PlayerOrder.Count;
			return _currentRoundIndex == playerCount - 1;
		}

		private void EndRound()
		{
			_context.ReplaceRound(_currentRoundCount + 1);
			_context.ReplaceRoundIndex(0);
		}

		private void EndTurn()
		{
			_context.ReplaceRoundIndex(_currentRoundIndex + 1);
		}
	}
}