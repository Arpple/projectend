using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

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
		foreach (var entity in _context.GetEntities(TileMatcher.Tile))
		{
			var view = UnityEngine.Object.Instantiate(_setting.TileController);
			view.SetSprite(entity.sprite.Sprite);
			view.name = "Tile " + entity.mapPosition;
			entity.AddView(view.gameObject);
			view.gameObject.Link(entity, _context);
			view.transform.SetParent(_setting.Container);
		}
	}

	public void TearDown()
	{
		foreach (var entity in _context.GetEntities(TileMatcher.Tile))
		{
			entity.view.GameObject.Unlink();
		}
	}
}
