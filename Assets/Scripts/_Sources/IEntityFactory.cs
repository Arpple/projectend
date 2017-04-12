using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IEntityFactory<TEntity, TData>
{
	TEntity CreateEntityWithComponents(TData data);
	void AddComponents(TEntity entity, TData data);
}
