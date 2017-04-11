using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

namespace Game
{
	public class TileViewLoadingSystem : IInitializeSystem, ITearDownSystem
	{
		private TileContext _context;
		private TileSetting _setting;

		public TileViewLoadingSystem(Contexts contexts, TileSetting setting)
		{
			_context = contexts.tile;
			_setting = setting;
		}

		public void Initialize()
		{
			foreach(var entity in _context.GetEntities(TileMatcher.GameTile))
			{
				var view = UnityEngine.Object.Instantiate(_setting.TileController);
				view.SetSprite(entity.gameSprite.Sprite);
				view.name = "Tile " + entity.gameMapPosition;
				entity.AddGameView(view.gameObject);
				view.gameObject.Link(entity, _context);
				view.transform.SetParent(_setting.Container);
			}
		}

		public void TearDown()
		{
			foreach (var entity in _context.GetEntities(TileMatcher.GameTile))
			{
				entity.gameView.GameObject.Unlink();
			}
		}
	}
}
