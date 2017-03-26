using System;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game
{
	public class CardObject : MonoBehaviour, ICustomView
	{
		public Image MainImage;

		public GameObject CreateView(GameEntity entity, Sprite sprite)
		{
			SetImage(sprite);

			return gameObject;
		}

		public void SetImage(Sprite image)
		{
			MainImage.sprite = image;
		}
	}

}
