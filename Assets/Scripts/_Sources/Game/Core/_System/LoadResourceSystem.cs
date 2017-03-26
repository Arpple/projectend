using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace End.Game
{
	public sealed class LoadResourceSystem : ReactiveSystem<GameEntity>, ITearDownSystem
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

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Resource, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasResource && !entity.hasView;
		}
			
		protected override void Execute (List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				//get sprite
				Sprite sprite = null;
				if (e.resource.SpritePath != null)
				{
					sprite = _cacheSprite.Get(e.resource.SpritePath, (path) => Resources.Load<Sprite>(path));
				}
			
				//get view object
				GameObject viewObject = null;
				if(e.resource.BasePrefabsPath != null)
				{
					var basePrefabs = Resources.Load<GameObject>(e.resource.BasePrefabsPath);
					if(basePrefabs == null) throw new MissingReferenceException("Resource " + e.resource.BasePrefabsPath);
					viewObject = GameObject.Instantiate(basePrefabs);
				}
				else
				{
					viewObject = new GameObject("EntityView");
				}

				//custom view
				var viewModifier = (ICustomView)viewObject.GetComponent(typeof(ICustomView));
				if (viewModifier != null)
				{
					viewObject = viewModifier.CreateView(e, sprite);
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

				e.AddView(viewObject);
				viewObject.Link(e, _context);
				_linkedObjects.Add(viewObject);
			}
		}

		public void TearDown()
		{
			_linkedObjects.ForEach(o => o.Unlink());
		}
	}
}
