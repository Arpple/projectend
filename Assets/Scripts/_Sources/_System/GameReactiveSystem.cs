using Entitas;

public abstract class GameReactiveSystem : ReactiveSystem<GameEntity>
{
	protected readonly GameContext _context;

	public GameReactiveSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}
}