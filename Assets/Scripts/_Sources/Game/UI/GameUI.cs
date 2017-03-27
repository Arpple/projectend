using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		public MainActionGroup MainGroup;
		public DeckCardActionGroup DeckGroup;

		public CardDescription CardDesc;

		private CardObject _activeCard;

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
			if(_activeCard != card)
			{
				_activeCard = card;
				CardDesc.SetDescription(card);
				CardDesc.gameObject.SetActive(true);
				MainGroup.ToggleButtons(false);

				//TODO: switch card type and call that group
				DeckGroup.ShowAction(card);
				

				//hightlight card
				//switch to card action
			}
			else
			{
				HideCardAction();
			}
		}

		public void HideCardAction()
		{
			CardDesc.gameObject.SetActive(false);
			_activeCard = null;

			//TODO: switch card type and call that group
			DeckGroup.CloseAction();

			MainGroup.ToggleButtons(true);
		}
	}
}
