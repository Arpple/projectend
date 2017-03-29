using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace End.Game.UI
{
	public class TileTargetSelector
	{
		private GameEntity[] _tiles;

		public TileTargetSelector(GameEntity[] tiles, Func<GameEntity, GameEntity> getTargetFromTileFunction, TileActionComponent.TileAction onTileSelected)
		{
			_tiles = tiles;

			foreach (var tile in _tiles)
			{
				Assert.IsTrue(tile.hasTile);
				Assert.IsTrue(tile.hasView);

				var con = tile.view.GameObject.GetComponent<TileController>();
				con.Span.enabled = true;

				var target = getTargetFromTileFunction(tile);
				if(target != null)
				{
					tile.AddTileAction((t) => 
					{
						onTileSelected(target);
						ClearSelection();
					});
				}
			}
		}

		public void ClearSelection()
		{
			foreach(var tile in _tiles)
			{
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
