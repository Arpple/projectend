using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	public class CardDescription : MonoBehaviour
	{
		public Text CardName;
		public Text CardDetail;

		public void Init()
		{
			Assert.IsNotNull(CardName);
			Assert.IsNotNull(CardDetail);
		}

		public void SetDescription(CardObject card)
		{
			//TODO: get description string
			CardName.text = card.name;
			CardDetail.text = "Desc " + card.name;
		}

		public void ToggleVisibility()
		{
			gameObject.SetActive(!gameObject.activeSelf);
		}
	}
}
