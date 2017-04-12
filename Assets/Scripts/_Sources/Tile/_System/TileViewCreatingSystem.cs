using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;
using System.Collections.Generic;

public class TileViewCreatingSystem : EntityViewCreatingSystem<TileEntity>
{
	private TileSetting _setting;
	private GameObject _container;

	public TileViewCreatingSystem(Contexts contexts, TileSetting setting, GameObject container) : base(contexts.tile)
	{
		_context = contexts.tile;
		_setting = setting;
		_container = container;
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.Sprite);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasSprite && !entity.hasView;
	}

	protected override GameObject CreateViewObject(TileEntity entity)
	{
		var obj = UnityEngine.Object.Instantiate(_setting.TileController);
		if(entity.sprite.Sprite != null)
		{
			obj.SetSprite(entity.sprite.Sprite);
		}
		obj.name = "Tile " + entity.mapPosition;
		obj.transform.SetParent(_container.transform, false);
		return obj.gameObject;
	}

	protected override void AddViewObject(TileEntity entity, GameObject viewObject)
	{
		entity.AddView(viewObject);
	}
}
