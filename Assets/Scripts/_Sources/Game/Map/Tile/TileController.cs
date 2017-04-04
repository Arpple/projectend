using UnityEngine;
using UnityEngine.EventSystems;
using Entitas.Unity;
using System;

namespace Game
{
	public class TileController : MonoBehaviour, ICustomView
	{
        private static GameObject _parent;

		public SpriteRenderer SelectionBorder;
		public SpriteRenderer Span;
		public SpriteRenderer TileSprite;
		public TileHoverAction MouseEnterAction;
		public Action<GameEntity> TileAction;
		public Action<GameEntity> DefaultTileAction;

        public delegate void TileHoverAction();

		public GameEntity Entity
		{
			get { return (GameEntity)gameObject.GetEntityLink().entity; }
		}

		private void Start()
		{
			SelectionBorder.enabled = false;
			Span.enabled = false;
		}

		void OnMouseDown()
		{
            if(EventSystem.current.IsPointerOverGameObject()) return;
			if (TileAction != null)
			{
				TileAction(Entity);
			}
			else
			{
				if (DefaultTileAction != null)
				{
					DefaultTileAction(Entity);
				}
			}
		}

		private void OnMouseEnter()
		{
            SelectionBorder.enabled = true;
            if(MouseEnterAction != null) {
                MouseEnterAction();
            }
		}

		private void OnMouseExit()
		{
            SelectionBorder.enabled = false;
		}

		public GameObject CreateView(GameEntity entity, Sprite sprite)
		{
			gameObject.name = "Tile " + entity.gameMapPosition;
			TileSprite.sprite = sprite;
			return gameObject;
		}
	}
}

