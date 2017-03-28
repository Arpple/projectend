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
		public CardContainer CardContainer;

		private CardObject _activeCard;

		private void Awake()
		{
			Instance = this;
			CardContainer.Init();
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

				if (card.Entity.isDeckCard)
				{
					MainGroup.ShowSubAction(DeckGroup);
					DeckGroup.SetAction(card);
					DeckGroup.OnCloseHandler += HideCardDescription;
				}
				
				//hightlight card
			}
			else
			{
				if (card.Entity.isDeckCard)
				{
					DeckGroup.CloseAction();
				}
			}
		}

		public void HideCardDescription()
		{
			CardDesc.gameObject.SetActive(false);
			_activeCard = null;
		}
	}
}
