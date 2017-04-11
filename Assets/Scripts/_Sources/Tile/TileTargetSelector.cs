using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using Entitas;

public class TileTargetSelector<TTarget> where TTarget : Entity
{
	private TileEntity[] _tiles;

	public TileTargetSelector(
		UnitEntity selector, TileEntity[] tiles,
		Func<UnitEntity, TileEntity, TTarget> getTargetFromTileFunction,
		UnityAction<TTarget> onTileSelected
	)
	{
		_tiles = tiles;

		foreach (var tile in _tiles)
		{
			Assert.IsTrue(tile.hasTile);
			Assert.IsTrue(tile.hasView);

			var con = tile.view.GameObject.GetComponent<TileController>();
			con.Span.enabled = true;

			var target = getTargetFromTileFunction(selector, tile);
			if (target != null)
			{
				tile.AddTileAction(() =>
				{
					onTileSelected(target);
					ClearSelection();
				});
			}
		}
	}

	public void ClearSelection()
	{
		foreach (var tile in _tiles)
		{
			var con = tile.view.GameObject.GetComponent<TileController>();
			con.Span.enabled = false;

			if (tile.hasTileAction)
			{
				tile.RemoveTileAction();
			}
		}
	}
}