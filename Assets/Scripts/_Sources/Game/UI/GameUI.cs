using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		public MainActionGroup MainGroup;
		public CardActionGroup CardGroup;

		public CardDescription CardDesc;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			MainGroup.Init();
			CardDesc.Init();
		}

		public void OnCardClicked(CardObject card)
		{
			//TODO: switch card type and call that group
			if(CardGroup.ActiveCard != card)
			{
				CardGroup.ActiveCard = card;

				CardDesc.SetDescription(card);
				CardDesc.gameObject.SetActive(true);
				//hightlight card
				//switch to card action
			}
			else
			{
				ResetAction();
			}
		}

		public void ResetAction()
		{
			CardDesc.gameObject.SetActive(false);
			CardGroup.ActiveCard = null;
		}
	}
}
