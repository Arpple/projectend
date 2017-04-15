using Entitas;

public abstract class TileReactiveSystem : ReactiveSystem<TileEntity>
{
	protected TileContext _context;

	public TileReactiveSystem(Contexts contexts) : base(contexts.tile)
	{
		_context = contexts.tile;
	}
}