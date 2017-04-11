using System.Linq;
using Entitas;

public class PlayingOrderSetupSystem : IInitializeSystem
{
	readonly GameContext _context;

	public PlayingOrderSetupSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		var players = _context.GetEntities(GameMatcher.Player);

		_context.SetPlayingOrder(players.OrderBy(p => p.player.PlayerId).ToList());
	}
}