using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

namespace Game
{
	public abstract class LoadResourceSystem<TEntity> : ReactiveSystem<TEntity>, ITearDownSystem, IInitializeSystem where TEntity : class, IEntity, new()
	{
		readonly IContext<TEntity> _context;

		protected CacheList<string, Sprite> _cacheSprite;
		protected List<GameObject> _linkedObjects;

		public LoadResourceSystem(IContext<TEntity> context) : base(context)
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
				if(Filter(e))
					LoadResource(e);
			}
		}
			
		protected override void Execute (List<TEntity> entities)
		{
			foreach(var e in entities)
			{
				LoadResource(e);
			}
		}

		public void TearDown()
		{
			_linkedObjects.ForEach(o => o.Unlink());
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

	public class TileResouceLoadSystem : LoadResourceSystem<TileEntity>
	{
		private TileContext _context;

		public TileResouceLoadSystem(Contexts contexts) : base(contexts.tile)
		{
			_context = contexts.tile;
		}

		protected override void AddViewComponent(TileEntity entity, GameObject view)
		{
			entity.AddGameView(view);
		}

		protected override bool Filter(TileEntity entity)
		{
			return entity.hasGameResource && !entity.hasGameView;
		}

		protected override TileEntity[] GetEntities()
		{
			return _context.GetEntities(TileMatcher.GameResource);
		}

		protected override ResourceComponent GetResourceComponent(TileEntity entity)
		{
			return entity.gameResource;
		}

		protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
		{
			return context.CreateCollector(TileMatcher.GameResource);
		}
	}

	public class GameResouceLoadSystem : LoadResourceSystem<GameEntity>
	{
		private GameContext _context;

		public GameResouceLoadSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override void AddViewComponent(GameEntity entity, GameObject view)
		{
			entity.AddGameView(view);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameResource && !entity.hasGameView;
		}

		protected override GameEntity[] GetEntities()
		{
			return _context.GetEntities(GameMatcher.GameResource);
		}

		protected override ResourceComponent GetResourceComponent(GameEntity entity)
		{
			return entity.gameResource;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameResource);
		}
	}
}
