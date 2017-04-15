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
			//e.AddMainMission((MainMission)e.player.PlayerObject.MainMissionId);
		}
	}
}