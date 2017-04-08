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

		[Header("Notification")]
		public TurnNotification TurnNoti;

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
			Assert.IsNotNull(TurnNoti);

			_currentGroup = MainGroup;
		}

		private void Start()
		{
			MainGroup.Init();
			CardDesc.Init();
			DeckFactory.Init();
			BoxFactory.Init();
			SkillFactory.Init();
		}

		private ActionGroup _currentGroup;

		public void OnCardClicked(CardObject card)
		{
			var group = (CardActionGroup)GetCardGroup(card);
			_currentGroup.ShowSubAction(group);
			group.OnCardClick(card);
		}


		//public void HideCardDescription()
		//{
		//	CardDesc.gameObject.SetActive(false);
		//	_activeCard = null;
		//}

		//private void SetUpMainGroup()
		//{
		//	foreach(var p in MainGroup.PanelButtons)
		//	{
		//		p.Button.onClick.AddListener(() =>
		//		{
		//			if (!p.Panel.activeSelf)
		//			{
		//				HideCardDescription();
		//			}
		//		});
		//	}
		//}

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
	}
}
