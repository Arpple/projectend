using Entitas;
using UnityEngine;

namespace Game
{
	[GameEvent]
	public class EventEndTurn : GameEventComponent
	{
		public static bool TryEndTurn()
		{
			if(Contexts.sharedInstance.game.IsLocalPlayerTurn)
			{
				GameEvent.CreateEvent<EventEndTurn>();
				return true;
			}
			return false;
		}
	}

	public class EventEndTurnSystem : GameEventSystem
	{
		private GameContext _gameContext;

		public EventEndTurnSystem(Contexts contexts) : base(contexts)
		{
			_gameContext = contexts.game;
		}

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.GameEventEndTurn, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.isGameEventEndTurn;
		}

		protected override void Process(GameEventEntity entity)
		{
			var cycler = new TurnRoundCycler(_gameContext);
			cycler.Cycle();
		}

		internal class TurnRoundCycler
		{
			private GameContext _context;
			private int _currentRoundIndex;
			private int _currentRoundCount;
			private int _currentTurn;

			public TurnRoundCycler(GameContext context)
			{
				_context = context;
				_currentRoundCount = _context.gameRound.Count;
				_currentRoundIndex = _context.gameRoundIndex.Index;
				_currentTurn = _context.gameTurn.Count;
			}

			public void Cycle()
			{
				if(IsRoundEnd())
				{
					EndRound();
				}
				else
				{
					EndTurn();
				}
				_context.ReplaceGameTurn(_currentTurn + 1);
			}

			private bool IsRoundEnd()
			{
				var playerCount = _context.gamePlayingOrder.PlayerOrder.Count;
				return _currentRoundIndex == playerCount - 1;
			}

			private void EndRound()
			{
				_context.ReplaceGameRound(_currentRoundCount + 1);
				_context.ReplaceGameRoundIndex(0);
			}

			private void EndTurn()
			{
				_context.ReplaceGameRoundIndex(_currentRoundIndex + 1);
			}
		}
	}
}
