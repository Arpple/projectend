using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

namespace Game.UI
{
	public abstract class CardActionGroup : ActionGroup
	{
		public GameObject CardPanel;

		public abstract void OnCardClick(CardObject card);
	}
}
