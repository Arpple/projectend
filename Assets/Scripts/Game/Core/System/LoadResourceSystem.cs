using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace End
{
	public sealed class LoadResourceSystem : ReactiveSystem<GameEntity>
	{
		readonly GameContext _context;

		private CacheList<string, Sprite> _cacheSprite;

		public LoadResourceSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_cacheSprite = new CacheList<string, Sprite>();
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
				var obj = new GameObject("EntityView");
				var spriteRenderer = obj.AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = _cacheSprite.Get(e.resource.SpritePath, (path) => Resources.Load<Sprite>(path));

				Debug.Log(spriteRenderer.sprite);

				e.AddView(obj);
				obj.Link(e, _context);
			}
		}

	}
}
