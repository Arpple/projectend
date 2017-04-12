using Entitas;

public abstract class ComponentFactory<TEntity, TData>
	where TEntity : class, IEntity, new()
	where TData : EntityData
{
	protected TEntity _entity;
	protected TData _data;

	public ComponentFactory(TEntity entity, TData data)
	{
		_entity = entity;
		_data = data;
	}

	public abstract void AddComponents();
}
