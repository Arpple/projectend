using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game.UI
{
	public class TargetUnitStatusDisplaySystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _gamecontext;
		private readonly TileContext _tileContext;
		private readonly PlayerUnitStatusPanel _panel;

		public TargetUnitStatusDisplaySystem(Contexts contexts, PlayerUnitStatusPanel panel) : base(contexts.game)
		{
			_tileContext = contexts.tile;
			_gamecontext = contexts.game;
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

		private void ShowDisplayStatus(GameEntity unit)
		{
			_panel.SetCharacter(unit);
			_panel.gameObject.SetActive(true);
			_panel.UpdateBoxCardCount(_gamecontext.GetPlayerBoxCards(unit.gameUnit.OwnerEntity).Length);
			_panel.UpdateDeckCardCount(_gamecontext.GetPlayerDeckCards(unit.gameUnit.OwnerEntity).Length);
		}

		private void HideDisplayStatus()
		{
			_panel.HideDisplay();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return new Collector<GameEntity>(
				new[] {
					context.GetGroup(GameMatcher.GameHitpoint),
					context.GetGroup(GameMatcher.GameUnitStatus)
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
			return _panel.ShowingCharacter == entity && entity.hasGameHitpoint && entity.hasGameUnitStatus;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				_panel.UpdateUnitHitpoint(e.gameHitpoint);
				_panel.UpdateUnitStatus(e.gameUnitStatus);
			}
		}
	}

}
