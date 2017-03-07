using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using UnityEngine.Assertions;

namespace End
{
	public class RenderTileSystem : ReactiveSystem<GameEntity>
	{
		readonly GameContext _context;
		readonly TileSetting _setting;

		public RenderTileSystem(Contexts contexts, TileSetting setting)
			: base(contexts.game)
		{
			_context = contexts.game;
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Tile, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasTile;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			GameObject viewRoot = GameObject.Find(_setting.ViewRootPath) ?? new GameObject("Tile");

			foreach(var e in entities)
			{
				Assert.IsTrue(e.hasView);

				GameObject baseTile = GameObject.Instantiate(_setting.BaseTileObject);
				baseTile.name = "Tile (" + e.mapPosition.X + "," + e.mapPosition.Y + ")";

				TileController con = baseTile.GetComponent<TileController>();
				Assert.IsNotNull(con);

				con.RegistView(e.view.GameObject);

				baseTile.transform.SetParent(viewRoot.transform, false);

				e.view.GameObject.Unlink();
				e.ReplaceView(baseTile);
				baseTile.Link(e, _context);
			}
		}
	}
}
