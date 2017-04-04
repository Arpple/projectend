using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.UI
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
		public SkillCardActionGroup SkillGroup;
		[Space]
		public CancelActionGroup CancelGroup;
		
		[Header("Components")]
		public CardDescription CardDesc;
		public PlayerUnitStatusPanel LocalPlayerStatus;
		public PlayerUnitStatusPanel TargetPlayerStatus;
		public TurnPanel TurnPanel;

		[Header("Factory")]
		public PlayerDeckFactory DeckFactory;
		public PlayerBoxFactory BoxFactory;
		public PlayerSkillFactory SkillFactory;

		private CardObject _activeCard;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(MainGroup);
			Assert.IsNotNull(DeckGroup);
			Assert.IsNotNull(BoxGroup);
			Assert.IsNotNull(SkillGroup);
			Assert.IsNotNull(CancelGroup);
			Assert.IsNotNull(CardDesc);
			Assert.IsNotNull(DeckFactory);
			Assert.IsNotNull(BoxFactory);
			Assert.IsNotNull(LocalPlayerStatus);
			Assert.IsNotNull(TargetPlayerStatus);
			Assert.IsNotNull(TurnPanel);
		}

		private void Start()
		{
			MainGroup.Init();
			CardDesc.Init();
			DeckFactory.Init();
			BoxFactory.Init();
			SkillFactory.Init();

			SetUpMainGroup();
		}

		public void OnCardClicked(CardObject card)
		{
			var cardEntity = card.Entity;
			if (!IsFocusingOnCard(card))
			{
				FocusOnCard(card);
			}
			else
			{
				CardDesc.ToggleVisibility();
			}
		}

		public void FocusOnCard(CardObject card)
		{
			var group = GetCardGroup(card);
			if (group != null)
			{
				if (IsFocusingOtherCardFrom(card))
				{
					group.CloseAction();
				}

				MainGroup.ShowSubAction(group);
				if (group is CardActionGroup)
				{
					var cardGroup = (CardActionGroup)group;
					cardGroup.SetAction(card);
				}
				group.OnCloseHandler += HideCardDescription;
			}

			_activeCard = card;
			CardDesc.SetDescription(card);
		}

		public void HideCardDescription()
		{
			CardDesc.gameObject.SetActive(false);
			_activeCard = null;
		}

		private void SetUpMainGroup()
		{
			foreach(var p in MainGroup.PanelButtons)
			{
				p.Button.onClick.AddListener(() =>
				{
					if (!p.Panel.activeSelf)
					{
						HideCardDescription();
					}
				});
			}
		}

		private ActionGroup GetCardGroup(CardObject card)
		{
			var entity = card.Entity;
			if (entity.isGameDeckCard)
			{
				if (entity.hasGameInBox)
					return BoxGroup;
				else
					return DeckGroup;
			}
			else if (entity.isGameSkillCard)
			{
				return SkillGroup;
			}
			return null;
		}

		private bool IsFocusingOnCard(CardObject card)
		{
			return _activeCard == card && _activeCard != null;
		}

		private bool IsFocusingOtherCardFrom(CardObject newFocusingCard)
		{
			return _activeCard != newFocusingCard && _activeCard != null;
		}
	}
}
