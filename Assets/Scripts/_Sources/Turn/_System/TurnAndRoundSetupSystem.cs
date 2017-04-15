using Entitas;

public class TurnAndRoundSetupSystem : IInitializeSystem
{
	private GameContext _context;

	public TurnAndRoundSetupSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		_context.SetRound(1);
		_context.SetRoundIndex(0);
		_context.SetTurn(1);
	}
}