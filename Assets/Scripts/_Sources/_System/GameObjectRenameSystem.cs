using System.Collections.Generic;
using Entitas;

public abstract class GameObjectRenameSystem<TEntity> : ReactiveSystem<TEntity> where TEntity : class, IEntity, new()
{
	public GameObjectRenameSystem(IContext<TEntity> context) : base(context)
	{ }

	protected override void Execute(List<TEntity> entities)
	{
		foreach(var e in entities)
		{
			var viewComp = GetViewComponent(e);
			viewComp.GameObject.name = GetNewName(e);
		}
	}

	protected abstract ViewComponent GetViewComponent(TEntity entity);
	protected abstract string GetNewName(TEntity entity);
}