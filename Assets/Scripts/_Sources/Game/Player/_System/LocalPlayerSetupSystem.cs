using System.Linq;
using Entitas;
using Network;

public class LocalPlayerSetupSystem : IInitializeSystem
{
	private readonly Player _localPlayer;
	private readonly GameContext _context;

	public LocalPlayerSetupSystem(Contexts contexts, Player localPlayer)
	{
		_localPlayer = localPlayer;
		_context = contexts.game;
	}

	public void Initialize()
	{
		var gameLocalPlayerEntity = _context.GetEntities(GameMatcher.Player).Where(p => p.player.PlayerObject == _localPlayer)
			.First();

		gameLocalPlayerEntity.isLocal = true;
	}
}
