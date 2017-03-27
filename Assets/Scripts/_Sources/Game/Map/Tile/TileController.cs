using UnityEngine;
using UnityEngine.EventSystems;
using Entitas.Unity;

namespace End.Game
{
	public class TileController : MonoBehaviour, ICustomView
	{
        private static GameObject _parent;

		public SpriteRenderer SelectionBorder;
		public SpriteRenderer Span;
		public SpriteRenderer TileSprite;
		public TileHoverAction MouseEnterAction;

		public delegate void TileClickAction();
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
            if(Entity.hasTileAction)
			{
				Entity.tileAction.OnSelected();
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
			gameObject.name = "Tile " + entity.mapPosition;
			TileSprite.sprite = sprite;
			return gameObject;
		}
	}
}

