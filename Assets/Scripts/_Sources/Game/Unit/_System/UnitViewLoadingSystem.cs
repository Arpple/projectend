﻿using Entitas;
using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;

namespace Game
{
	public class UnitViewLoadingSystem : ReactiveSystem<UnitEntity>, IInitializeSystem, ITearDownSystem
	{
		private UnitContext _context;
		private UnitSetting _setting;
		private List<GameObject> _linkedObjects;
		private GameObject _container;

		public UnitViewLoadingSystem(Contexts contexts, UnitSetting setting) : base(contexts.unit)
		{
			_context = contexts.unit;
			_setting = setting;
			_linkedObjects = new List<GameObject>();
		}

		public void Initialize()
		{
			_container = CreateViewContainer();

			foreach (var e in _context.GetEntities(UnitMatcher.GameResource))
			{
				if (Filter(e))
				{
					LoadResource(e);
				}
			}
		}

		private GameObject CreateViewContainer()
		{
			var obj = Object.Instantiate(_setting.UnitContainerPrefabs) as GameObject;
			return obj ?? new GameObject("Units");
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameResource);
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach (var e in entities)
			{
				LoadResource(e);
			}
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.hasGameResource && !entity.hasGameView;
		}

		private void LoadResource(UnitEntity entity)
		{
			var loader = new UnitResourceLoader(entity);
			var sprite = loader.LoadSprite();
			var view = new GameObject(entity.gameUnitDetail.Name);
			view.transform.SetParent(_container.transform, false);

			var sr = view.AddComponent<SpriteRenderer>();
			sr.sprite = sprite;
			sr.sortingLayerName = "Unit";

			entity.AddGameView(view.gameObject);
			view.gameObject.Link(entity, _context);
			_linkedObjects.Add(view.gameObject);
		}

		public void TearDown()
		{
			_linkedObjects.ForEach(o => o.Unlink());
			_linkedObjects.Clear();
		}

		internal class UnitResourceLoader
		{
			private UnitEntity _unit;

			public UnitResourceLoader(UnitEntity entity)
			{
				_unit = entity;
			}

			public Sprite LoadSprite()
			{
				var sprite = Resources.Load<Sprite>(_unit.gameResource.SpritePath);
				if (sprite == null)
				{
					throw new MissingReferenceException(_unit.gameResource.SpritePath);
				}

				return sprite;
			}
		}

	}

}
