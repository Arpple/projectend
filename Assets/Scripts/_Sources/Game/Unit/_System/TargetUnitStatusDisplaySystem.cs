using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class TargetUnitStatusDisplaySystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _panel;

		public TargetUnitStatusDisplaySystem(Contexts contexts, PlayerUnitStatusPanel panel) : base(contexts.game)
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
			_panel.HideDisplay();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return new Collector<GameEntity>(
				new[] {
					context.GetGroup(GameMatcher.Hitpoint),
					context.GetGroup(GameMatcher.UnitStatus)
				}, 
				new[] 
				{
					GroupEvent.Added,
					GroupEvent.Added,
				}
			);
		}

		protected override bool Filter(GameEntity entity)
		{
			return _panel.ShowingCharacter == entity && entity.hasHitpoint && entity.hasUnitStatus;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				_panel.UpdateUnitHitpoint(e.hitpoint);
				_panel.UpdateUnitStatus(e.unitStatus);
			}
		}
	}

}
