using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		public MainActionGroup MainGroup;

		[Space(15)]
		public DeckCardActionGroup DeckGroup;

		[Space(15)]
		public BoxCardActionGroup BoxGroup;

		[Space(15)]
		public CancelActionGroup CancelGroup;

		[Space(15)]
		public CardDescription CardDesc;

		public CardContainer CardContainer;
		public BoxContainer BoxContainer;

		private CardObject _activeCard;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			MainGroup.Init();
			CardDesc.Init();
			CardContainer.Init();
			BoxContainer.Init();
		}

		public void OnCardClicked(CardObject card)
		{
			var cardEntity = card.Entity;
			if (_activeCard != card)
			{
				_activeCard = card;
				CardDesc.SetDescription(card);
				CardDesc.gameObject.SetActive(true);

				if (cardEntity.isDeckCard)
				{
					if (cardEntity.hasInBox)
					{
						MainGroup.ShowSubAction(BoxGroup);
						BoxGroup.SetAction(card);
						BoxGroup.OnCloseHandler += HideCardDescription;
					}
					else
					{
						MainGroup.ShowSubAction(DeckGroup);
						DeckGroup.SetAction(card);
						DeckGroup.OnCloseHandler += HideCardDescription;
					}
				}
				
				//hightlight card
			}
			else
			{
				if (cardEntity.isDeckCard)
				{
					if (cardEntity.hasInBox)
					{
						BoxGroup.CloseAction();
					}
					else
					{
						DeckGroup.CloseAction();
					}
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
