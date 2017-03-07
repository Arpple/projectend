using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace End
{
	public sealed class LoadResourceSystem : ReactiveSystem<GameEntity>
	{
		readonly GameContext _context;

		public LoadResourceSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
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
				var obj = new GameObject("NewEntityView");
				var spriteRenderer = obj.AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = e.resource.Sprite;

				e.AddView(obj);
				obj.Link(e, _context);
			}
		}

	}
}
