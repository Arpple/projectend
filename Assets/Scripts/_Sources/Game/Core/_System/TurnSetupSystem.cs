using UnityEngine;
using Entitas;

namespace Game
{
	public class TurnSetupSystem : IInitializeSystem
	{
		private GameContext _context;

		public TurnSetupSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			_context.SetGameTurn(1);
		}
	}
}
