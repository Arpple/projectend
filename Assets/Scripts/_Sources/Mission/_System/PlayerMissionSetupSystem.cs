using Entitas;

public class PlayerMissionSetupSystem : IInitializeSystem
{
	private GameContext _context;

	public PlayerMissionSetupSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		foreach(var e in _context.GetEntities(GameMatcher.Player))
		{
			e.AddPlayerMission((PlayerMission)e.player.GetNetworkPlayer().PlayerMissionId);
		}
	}
}