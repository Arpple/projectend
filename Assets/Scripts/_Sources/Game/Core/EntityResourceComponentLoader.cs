using Entitas;
using UnityEngine;

namespace Game
{
	public class EntityResourceComponentLoader<TEntity> where TEntity : class, IEntity, new()
	{
		private TEntity _entity;
		private ResourceComponent _resource;

		public EntityResourceComponentLoader(TEntity entity, ResourceComponent resource)
		{
			_entity = entity;
			_resource = resource;
		}

		public GameObject Load()
		{
			var viewObject = _resource.BasePrefabsPath != null
				? LoadViewObject()
				: CreateDefaultObject();

			var sprite = GetSprite();

			IEntityCustomView<TEntity> customView;
			if (TryGetCustomView(viewObject, out customView))
			{
				viewObject = customView.CreateView(_entity, sprite);
			}
			else
			{
				var spriteRenderer = viewObject.GetComponentInChildren<SpriteRenderer>();
				if (spriteRenderer == null) spriteRenderer = viewObject.AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = sprite;
				spriteRenderer.sortingLayerName = "Unit";
				spriteRenderer.sortingOrder = 5;
			}

			return viewObject;
		}

		private GameObject CreateDefaultObject()
		{
			return new GameObject("Entity View");
		}

		private Sprite GetSprite()
		{
			return Resources.Load<Sprite>(_resource.SpritePath);
		}

		private GameObject LoadViewObject()
		{
			var res = Resources.Load<GameObject>(_resource.BasePrefabsPath);
			if(res == null)
			{
				throw new MissingReferenceException(_resource.BasePrefabsPath);
			}

			return Object.Instantiate(res) as GameObject;
		}

		private bool TryGetCustomView(GameObject view, out IEntityCustomView<TEntity> customView)
		{
			customView = view.GetComponent(typeof(IEntityCustomView<TEntity>)) as IEntityCustomView<TEntity>;
			return customView != null;
		}
	}
}