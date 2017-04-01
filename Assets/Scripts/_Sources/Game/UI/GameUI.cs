using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		[Header("Action")]
		public MainActionGroup MainGroup;
		[Space]
		public DeckCardActionGroup DeckGroup;
		[Space]
		public BoxCardActionGroup BoxGroup;
		[Space]
		public CancelActionGroup CancelGroup;
		
		[Header("Components")]
		public CardDescription CardDesc;
		public CardContainer CardContainer;
		public BoxContainer BoxContainer;
		public UnitStatusPanel LocalCharacterStatus;

		private CardObject _activeCard;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(MainGroup);
			Assert.IsNotNull(DeckGroup);
			Assert.IsNotNull(BoxGroup);
			Assert.IsNotNull(CancelGroup);
			Assert.IsNotNull(CardDesc);
			Assert.IsNotNull(CardContainer);
			Assert.IsNotNull(BoxContainer);
			Assert.IsNotNull(LocalCharacterStatus);
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
