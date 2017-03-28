using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class TileTargetSelector
	{
		private GameEntity[] _tiles;

		public TileTargetSelector(GameEntity[] tiles, TileActionComponent.TileAction onTileSelected)
		{
			_tiles = tiles;

			foreach (var tile in _tiles)
			{
				Assert.IsTrue(tile.hasTile);
				Assert.IsTrue(tile.hasView);

				var con = tile.view.GameObject.GetComponent<TileController>();
				con.Span.enabled = true;

				tile.AddTileAction((t) => {
					onTileSelected(t);
					ClearSelection();
				});
			}
		}

		public void ClearSelection()
		{
			foreach(var tile in _tiles)
			{
				Assert.IsTrue(tile.hasTileAction);

				var con = tile.view.GameObject.GetComponent<TileController>();
				con.Span.enabled = false;

				tile.RemoveTileAction();
			}
		}
	}

}
