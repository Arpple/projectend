using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace Game
{
	public sealed class LoadResourceSystem : ReactiveSystem<GameEntity>, ITearDownSystem, IInitializeSystem
	{
		readonly GameContext _context;

		private CacheList<string, Sprite> _cacheSprite;
		private List<GameObject> _linkedObjects;

		public LoadResourceSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_cacheSprite = new CacheList<string, Sprite>();
			_linkedObjects = new List<GameObject>();
		}

		public void Initialize()
		{
			foreach(var e in _context.GetEntities(GameMatcher.GameResource))
			{
				if(!e.hasGameView)
				{
					LoadResource(e);
				}
			}
		}

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameResource, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasGameResource && !entity.hasGameView;
		}
			
		protected override void Execute (List<GameEntity> entities)
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

		private void LoadResource(GameEntity entity)
		{
			//get sprite
			Sprite sprite = null;
			if (entity.gameResource.SpritePath != null)
			{
				sprite = _cacheSprite.Get(entity.gameResource.SpritePath, (path) => Resources.Load<Sprite>(path));
			}

			//get view object
			GameObject viewObject = null;
			if (entity.gameResource.BasePrefabsPath != null)
			{
				var basePrefabs = Resources.Load<GameObject>(entity.gameResource.BasePrefabsPath);
				if (basePrefabs == null) throw new MissingReferenceException("Resource " + entity.gameResource.BasePrefabsPath);
				viewObject = GameObject.Instantiate(basePrefabs);
			}
			else
			{
				viewObject = new GameObject("EntityView");
			}

			//custom view
			var viewModifier = (IEntityView<GameEntity>)viewObject.GetComponent(typeof(IEntityView<GameEntity>));
			if (viewModifier != null)
			{
				viewObject = viewModifier.CreateView(entity, sprite);
			}

			//default view
			else
			{
				var spriteRenderer = viewObject.GetComponentInChildren<SpriteRenderer>();
				if (spriteRenderer == null) spriteRenderer = viewObject.AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = sprite;
				spriteRenderer.sortingLayerName = "Unit";
				spriteRenderer.sortingOrder = 5;
			}

			entity.AddGameView(viewObject);
			viewObject.Link(entity, _context);
			_linkedObjects.Add(viewObject);
		}
	}
}
