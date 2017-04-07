using UnityEngine;
using Entitas;

namespace Game
{
	public class TurnAndRoundSetupSystem : IInitializeSystem
	{
		private GameContext _context;

		public TurnAndRoundSetupSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			_context.SetGameRound(1);
			_context.SetGameRoundIndex(0);
			_context.SetGameTurn(1);
		}
	}
}
