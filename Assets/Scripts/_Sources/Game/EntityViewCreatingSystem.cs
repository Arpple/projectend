using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public abstract class EntityViewCreatingSystem<TEntity> : ReactiveSystem<TEntity>, ITearDownSystem
	where TEntity : class, IEntity, new()
{
	protected List<GameObject> _linkedObjects;
	protected IContext<TEntity> _context;

	public EntityViewCreatingSystem(IContext<TEntity> context) : base(context)
	{
		_linkedObjects = new List<GameObject>();
	}

	protected override void Execute(List<TEntity> entities)
	{
		foreach(var e in entities)
		{
			var viewObj = CreateViewObject(e);
			AddViewObject(e, viewObj);
			LinkObject(e, viewObj);
		}
	}

	protected abstract GameObject CreateViewObject(TEntity entity);
	protected abstract void AddViewObject(TEntity entity, GameObject viewObject);

	protected void LinkObject(TEntity entity, GameObject obj)
	{
		obj.Link(entity, _context);
		_linkedObjects.Add(obj);
	}

	public void TearDown()
	{
		foreach (var obj in _linkedObjects)
		{
			if(obj != null)
				obj.Unlink();
		}
	}
}
