using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Blueprints;

namespace End.MapEditor
{
	public class TileBrushSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		public static TileBrushComponent TileBrush;

		readonly GameContext _context;
		readonly TileSetting _setting;

		public TileBrushSystem(Contexts contexts, TileSetting setting)
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

		public void Initialize()
		{
			_context.SetTileBrush(Tile.DeepForest, BrushAction.Click);
			TileBrush = _context.tileBrush;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			var brushTile = _context.tileBrush.TileType;

			foreach(var e in entities)
			{
				e.AddTileAction(null, e, (none, tileEntity) => {
					if(tileEntity.tile.Type == brushTile) return;

					//remove old view
					var link = tileEntity.view.GameObject.GetEntityLink();
					link.Unlink();
					GameObject.Destroy(tileEntity.view.GameObject);

					var pos = e.mapPosition;
					e.RemoveAllComponents();

					e.ApplyBlueprint(_setting.GetTileBlueprint(brushTile));
					e.AddTile(brushTile);
					e.AddMapPosition(pos.X, pos.Y);
				});
			}
		}
	}
}
