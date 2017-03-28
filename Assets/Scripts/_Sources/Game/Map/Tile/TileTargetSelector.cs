using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace End.Game.UI
{
	public class TileTargetSelector
	{
		private GameEntity[] _tiles;

		public TileTargetSelector(GameEntity[] tiles, Func<GameEntity, bool> tilesActionFilter, TileActionComponent.TileAction onTileSelected)
		{
			_tiles = tiles;

			foreach (var tile in _tiles)
			{
				Assert.IsTrue(tile.hasTile);
				Assert.IsTrue(tile.hasView);

				var con = tile.view.GameObject.GetComponent<TileController>();
				con.Span.enabled = true;

				if(tilesActionFilter(tile))
				{
					tile.AddTileAction((t) => 
					{
						onTileSelected(t);
						ClearSelection();
					});
				}
			}
		}

		public void ClearSelection()
		{
			foreach(var tile in _tiles)
			{
				Assert.IsTrue(tile.hasTileAction);

				var con = tile.view.GameObject.GetComponent<TileController>();
				con.Span.enabled = false;

				if(tile.hasTileAction)
				{
					tile.RemoveTileAction();
				}
			}
		}
	}

}
