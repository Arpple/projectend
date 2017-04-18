public interface IEntityFactory<TEntity, TData>
{
	TEntity CreateEntityWithComponents(TData data);
	void AddComponents(TEntity entity, TData data);
}
