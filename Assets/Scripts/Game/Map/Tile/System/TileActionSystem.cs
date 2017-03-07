using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.Assertions;

namespace End
{
	public class TileActionSystem : ReactiveSystem<GameEntity>, ITearDownSystem
	{
		readonly GameContext _context;

		public TileActionSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.TileAction, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasTileAction;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				Assert.IsTrue(e.hasView);
				Assert.IsTrue(e.hasTile);

				var tileCon = e.view.GameObject.GetComponent<TileController>();
				Assert.IsNotNull(tileCon);

				var tileAction = e.tileAction;
				tileCon.ClickAction = () => tileAction.SelectedAction(tileAction.Source, tileAction.Target);
			}
		}

		public void TearDown ()
		{
			foreach(var e in _context.GetEntities(GameMatcher.Tile))
			{
				var tileCon = e.view.GameObject.GetComponent<TileController>();
				Assert.IsNotNull(tileCon);

				tileCon.ClickAction = null;
			}
		}
	}

}
