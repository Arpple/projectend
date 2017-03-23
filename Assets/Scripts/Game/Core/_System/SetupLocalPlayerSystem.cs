using System.Linq;
using Entitas;

namespace End.Game
{
	public class SetupLocalPlayerSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public SetupLocalPlayerSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			_context.GetEntities(GameMatcher.Player)
				.Where(p => p.player.PlayerId == GameController.LocalPlayer.PlayerId)
				.First()
				.isLocalPlayer = true;
		}
	}
}

