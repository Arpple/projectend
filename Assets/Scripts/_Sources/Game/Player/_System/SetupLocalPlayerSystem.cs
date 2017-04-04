using System.Linq;
using Entitas;

namespace Game
{
	public class SetupLocalPlayerSystem : IInitializeSystem
	{
		private readonly Player _localPlayer;
		private readonly GameContext _context;

		public SetupLocalPlayerSystem(Contexts contexts, Player localPlayer)
		{
			_localPlayer = localPlayer;
			_context = contexts.game;
		}

		public void Initialize()
		{
			var localPlayerEntity = _context.GetEntities(GameMatcher.Player).Where(p => p.player.PlayerObject == _localPlayer)
				.First();

			localPlayerEntity.isLocalPlayer = true;
		}
	}
}

