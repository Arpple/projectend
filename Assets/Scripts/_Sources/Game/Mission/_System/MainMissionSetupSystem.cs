using Entitas;

public class MainMissionSetupSystem : IInitializeSystem
{
	private GameContext _context;

	public MainMissionSetupSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		var player = _context.localEntity;
		_context.SetMainMission((MainMission)player.player.PlayerObject.MainMissionId);
	}
}