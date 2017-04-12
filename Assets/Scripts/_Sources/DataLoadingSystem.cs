using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

public abstract class DataLoadingSystem<TEntity, TData> : ReactiveSystem<TEntity>
	where TEntity : class, IEntity, new()
	where TData : EntityData
{
	private EntityFactory<TEntity, TData> _factory;
	private IContext<TEntity> _context;

	public DataLoadingSystem(IContext<TEntity> context) : base(context)
	{
		_factory = CreateEntityFactory(context);
	}

	protected abstract EntityFactory<TEntity, TData> CreateEntityFactory(IContext<TEntity> context);
	protected abstract TData GetData(TEntity entity);

	protected override void Execute(List<TEntity> entities)
	{
		foreach(var e in entities)
		{
			_factory.AddComponents(e, GetData(e));
		}
	}
}
