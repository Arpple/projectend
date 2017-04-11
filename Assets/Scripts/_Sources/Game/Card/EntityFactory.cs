using UnityEngine;
using System.Collections;
using Entitas;

namespace Game
{
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

		public abstract void AddComponents(TEntity entity, TData data);
	}
}