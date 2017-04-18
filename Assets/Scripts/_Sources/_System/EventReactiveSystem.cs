using Entitas;

public abstract class EventReactiveSystem : ReactiveSystem<GameEventEntity>
{
	protected readonly GameEventContext _context;

	public EventReactiveSystem(Contexts contexts) : base(contexts.gameEvent)
	{
		_context = contexts.gameEvent;
	}
}