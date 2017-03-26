using UnityEngine;
using UnityEngine.EventSystems;

namespace End.Game
{
	public class TileController : MonoBehaviour, ICustomView
	{
        private static GameObject _parent;

		public SpriteRenderer SelectionBorder;
		public SpriteRenderer TileSprite;
		public TileClickAction ClickAction;
        public TileHoverAction MouseEnterAction;

		public delegate void TileClickAction();
        public delegate void TileHoverAction();

		void OnMouseDown()
		{
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if(ClickAction != null)
			{
				ClickAction();
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

