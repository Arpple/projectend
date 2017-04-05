using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using Entitas;

namespace Game.UI
{
	public class TileTargetSelector<TTarget> where TTarget : Entity
	{
		private GameEntity[] _tiles;

		public TileTargetSelector(
			GameEntity selector, GameEntity[] tiles, 
			Func<GameEntity, GameEntity, TTarget> getTargetFromTileFunction, 
			UnityAction<TTarget> onTileSelected
		)
		{
			_tiles = tiles;

			foreach (var tile in _tiles)
			{
				Assert.IsTrue(tile.hasGameTile);
				Assert.IsTrue(tile.hasGameView);

				var con = tile.gameView.GameObject.GetComponent<TileController>();
				con.Span.enabled = true;

				var target = getTargetFromTileFunction(selector, tile);
				if(target != null)
				{
					tile.AddGameTileAction(() => 
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
				var con = tile.gameView.GameObject.GetComponent<TileController>();
				con.Span.enabled = false;

				if(tile.hasGameTileAction)
				{
					tile.RemoveGameTileAction();
				}
			}
		}
	}

}
