using Entitas;

public abstract class BuffReactiveSystem : ReactiveSystem<BuffEntity>
{
	protected BuffContext _context;

	public BuffReactiveSystem(Contexts contexts) : base(contexts.buff)
	{
		_context = contexts.buff;
	}
}