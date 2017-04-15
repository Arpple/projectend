using Entitas;

public abstract class UnitReactiveSystem : ReactiveSystem<UnitEntity>
{
	protected UnitContext _context;

	public UnitReactiveSystem(Contexts contexts) : base(contexts.unit)
	{
		_context = contexts.unit;
	}
}