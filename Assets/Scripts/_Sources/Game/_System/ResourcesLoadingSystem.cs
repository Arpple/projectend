using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public abstract class ResourcesLoadingSystem<TEntity> : ReactiveSystem<TEntity>, ITearDownSystem, IInitializeSystem where TEntity : class, IEntity, new()
{
	readonly IContext<TEntity> _context;

	protected CacheList<string, Sprite> _cacheSprite;
	protected List<GameObject> _linkedObjects;

	public ResourcesLoadingSystem(IContext<TEntity> context) : base(context)
	{
		_context = context;
		_cacheSprite = new CacheList<string, Sprite>();
		_linkedObjects = new List<GameObject>();
	}

	protected abstract TEntity[] GetEntities();

	public void Initialize()
	{
		foreach (var e in GetEntities())
		{
			if (Filter(e))
				LoadResource(e);
		}
	}

	protected override void Execute(List<TEntity> entities)
	{
		foreach (var e in entities)
		{
			LoadResource(e);
		}
	}

	public void TearDown()
	{
		_linkedObjects.ForEach(o => o.Unlink());
		_linkedObjects.Clear();
	}

	private void LoadResource(TEntity entity)
	{
		var resource = GetResourceComponent(entity);
		var loader = new EntityResourceComponentLoader<TEntity>(entity, resource);
		var viewObject = loader.Load();

		AddViewComponent(entity, viewObject);
		viewObject.Link(entity, _context);
		_linkedObjects.Add(viewObject);
	}

	protected abstract ResourceComponent GetResourceComponent(TEntity entity);
	protected abstract void AddViewComponent(TEntity entity, GameObject view);
}

public class GameResouceLoadingSystem : ResourcesLoadingSystem<GameEntity>
{
	private GameContext _context;

	public GameResouceLoadingSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override void AddViewComponent(GameEntity entity, GameObject view)
	{
		entity.AddView(view);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasResource && !entity.hasView;
	}

	protected override GameEntity[] GetEntities()
	{
		return _context.GetEntities(GameMatcher.Resource);
	}

	protected override ResourceComponent GetResourceComponent(GameEntity entity)
	{
		return entity.resource;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Resource);
	}
}