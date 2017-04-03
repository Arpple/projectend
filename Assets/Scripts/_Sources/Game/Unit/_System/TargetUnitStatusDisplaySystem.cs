using UnityEngine;
using Entitas;

namespace End.Game.UI
{
	public class TargetUnitStatusDisplaySystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _panel;

		public TargetUnitStatusDisplaySystem(Contexts contexts, PlayerUnitStatusPanel panel)
		{
			_context = contexts.game;
			_panel = panel;
		}

		public void Initialize()
		{
			foreach(var tile in _context.GetEntities(GameMatcher.Tile))
			{
				var tileCon = tile.view.GameObject.GetComponent<TileController>();
				tileCon.DefaultTileAction = OnTileClicked;
			}
		}

		private void OnTileClicked(GameEntity tile)
		{
			var unit = tile.GetUnitOnTile();
			if(unit != null)
			{
				ShowDisplayStatus(unit);
			}
			else
			{
				HideDisplayStatus();
			}
		}

		private void ShowDisplayStatus(GameEntity unit)
		{
			_panel.SetCharacter(unit);
			_panel.gameObject.SetActive(true);
		}

		private void HideDisplayStatus()
		{
			_panel.gameObject.SetActive(false);
		}
	}

}
