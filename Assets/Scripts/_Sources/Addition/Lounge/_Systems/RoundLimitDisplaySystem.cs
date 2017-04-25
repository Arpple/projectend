using Entitas;

namespace Lounge
{
	public class RoundLimitDisplaySystem : IInitializeSystem
	{
		private GameContext _context;
		private RoundDisplay _display;

		public RoundLimitDisplaySystem(Contexts contexts, RoundDisplay roundDisplay)
		{
			_context = contexts.game;
			_display = roundDisplay;
		}

		public void Initialize()
		{
			_display.SetRoundLimit(_context.localEntity.player.GetNetworkPlayer().RoundLimit);
		}
	}
}
