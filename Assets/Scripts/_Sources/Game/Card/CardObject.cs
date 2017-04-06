using System;
using UnityEngine;
using UnityEngine.UI;
using Entitas.Unity;

namespace Game.UI
{
	public class CardObject : MonoBehaviour
	{
		public Image MainImage;

		public CardEntity Entity
		{
			get { return (CardEntity)gameObject.GetEntityLink().entity; }
		}

		public void SetAbilityImage(Sprite sprite)
		{
			MainImage.sprite = sprite;
		}

		public void OnClick()
		{
			GameUI.Instance.OnCardClicked(this);
		}
	}

}
