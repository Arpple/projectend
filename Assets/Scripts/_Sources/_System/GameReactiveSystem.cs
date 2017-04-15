using Entitas;

public abstract class GameReactiveSystem : ReactiveSystem<GameEntity>
{
	protected GameContext _context;

	public GameReactiveSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}
}