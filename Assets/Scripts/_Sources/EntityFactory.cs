using Entitas;

public abstract class EntityFactory<TEntity, TData>
	where TEntity : class, IEntity, new()
	where TData : EntityData
{
	protected IContext<TEntity> _context;

	public EntityFactory(IContext<TEntity> context)
	{
		_context = context;
	}

	public virtual TEntity CreateEntityWithComponents(TData data)
	{
		var entity = _context.CreateEntity();
		AddComponents(entity, data);
		return entity;
	}

	public virtual void AddComponents(TEntity entity, TData data)
	{
		var componentFactory = CreateComponentFactory(entity, data);
		componentFactory.AddComponents();
	}

	protected abstract ComponentFactory<TEntity, TData> CreateComponentFactory(TEntity entity, TData data);
}