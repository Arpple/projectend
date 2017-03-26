using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class CardActionGroup
	{
		public CardDescription Description;

		public CardObject ActiveCard;

		public void Init(CardDescription cardDesc)
		{
			Description = cardDesc;
		}

		public void Reset()
		{
			Description.gameObject.SetActive(false);
		}
	}
}
