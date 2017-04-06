using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game.UI
{
	public class TargetUnitStatusDisplaySystem : ReactiveSystem<UnitEntity>, IInitializeSystem
	{
		private readonly TileContext _tileContext;
		private readonly CardContext _cardContext;
		private readonly PlayerUnitStatusPanel _panel;

		public TargetUnitStatusDisplaySystem(Contexts contexts, PlayerUnitStatusPanel panel) : base(contexts.unit)
		{
			_tileContext = contexts.tile;
			_cardContext = contexts.card;
			_panel = panel;
		}

		public void Initialize()
		{
			foreach(var tile in _tileContext.GetEntities(TileMatcher.GameTile))
			{
				var tileCon = tile.gameView.GameObject.GetComponent<TileController>();
				tileCon.DefaultTileAction = OnTileClicked;
			}
		}

		private void OnTileClicked(TileEntity tile)
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

		private void ShowDisplayStatus(UnitEntity unit)
		{
			_panel.SetCharacter(unit);
			_panel.gameObject.SetActive(true);
			_panel.UpdateBoxCardCount(_cardContext.GetPlayerBoxCards(unit.gameOwner.Entity).Length);
			_panel.UpdateDeckCardCount(_cardContext.GetPlayerDeckCards(unit.gameOwner.Entity).Length);
		}

		private void HideDisplayStatus()
		{
			_panel.HideDisplay();
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return new Collector<UnitEntity>(
				new[] {
					context.GetGroup(UnitMatcher.GameHitpoint),
					context.GetGroup(UnitMatcher.GameUnitStatus)
				}, 
				new[] 
				{
					GroupEvent.Added,
					GroupEvent.Added,
				}
			);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return _panel.ShowingCharacter == entity && entity.hasGameHitpoint && entity.hasGameUnitStatus;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach(var e in entities)
			{
				_panel.UpdateUnitHitpoint(e.gameHitpoint);
				_panel.UpdateUnitStatus(e.gameUnitStatus);
			}
		}
	}

}
