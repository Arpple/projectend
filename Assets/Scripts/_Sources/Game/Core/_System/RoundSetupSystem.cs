using UnityEngine;
using Entitas;

namespace Game
{
	public class RoundSetupSystem : IInitializeSystem
	{
		private GameContext _context;

		public RoundSetupSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			_context.SetGameRound(1);
		}
	}
}
