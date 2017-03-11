using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End
{
	public class TileController : MonoBehaviour, ICustomView
	{
		private static GameObject _parent;

		public string ParentName;
		public SpriteRenderer SelectionBorder;
		public SpriteRenderer TileSprite;
		public TileClickAction ClickAction;

		public delegate void TileClickAction();

		public GameObject Parent
		{
			get
			{
				if(_parent == null)
				{
					_parent = GameObject.Find(ParentName) ?? new GameObject("Tile");
				}
				return _parent;
			}
		}

		private void Start()
		{
			transform.SetParent(Parent.transform, false);
		}

		void OnMouseDown()
		{
			if(ClickAction != null)
			{
				ClickAction();
			}
		}

		private void OnMouseEnter()
		{
			SelectionBorder.enabled = true;
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

