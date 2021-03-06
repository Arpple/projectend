﻿using UnityEngine;
using UnityEngine.EventSystems;
using Entitas.Unity;
using System;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
	private static GameObject _parent;

	public SpriteRenderer SelectionBorder;
	public SpriteRenderer Span;
	public SpriteRenderer TileSprite;
	public UnityAction MouseEnterAction;
	public UnityAction TileAction;
	public UnityAction<TileEntity> DefaultTileAction;

	public delegate void TileHoverAction();

	public TileEntity Entity
	{
		get { return (TileEntity)gameObject.GetEntityLink().entity; }
	}

	private void Start()
	{
		SelectionBorder.enabled = false;
		Span.enabled = false;
	}

	void OnMouseDown()
	{
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
		if (TileAction != null)
		{
			TileAction();
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
		if (MouseEnterAction != null)
		{
			MouseEnterAction();
		}
	}

	private void OnMouseExit()
	{
		SelectionBorder.enabled = false;
	}

	public void SetSprite(Sprite sprite)
	{
		TileSprite.sprite = sprite;
	}
}