using System;
using UnityEngine;
using UnityEngine.UI;
using Entitas.Unity;

namespace Game.UI
{
	public class CardObject : MonoBehaviour, IEntityCustomView<GameEntity>
	{
		public Image MainImage;

		public CardEntity Entity
		{
			get { return (CardEntity)gameObject.GetEntityLink().entity; }
		}

		public GameObject CreateView(GameEntity entity, Sprite sprite)
		{
			MainImage.sprite = sprite;

			return gameObject;
		}

		public void OnClick()
		{
			GameUI.Instance.OnCardClicked(this);
		}
	}

}
