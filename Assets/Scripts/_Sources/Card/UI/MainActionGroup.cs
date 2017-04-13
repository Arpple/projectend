using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[Serializable]
public class MainActionGroup : CardActionGroup
{
	[Serializable]
	public class PanelToggleButton
	{
		public Button Button;
		public GameObject Panel;

		public void Init()
		{
			Assert.IsNotNull(Button);
			Assert.IsNotNull(Panel);

			Button.onClick.AddListener(TogglePanel);
		}

		public void TogglePanel()
		{
			Panel.SetActive(!Panel.activeSelf);
		}
	}

	public Button EndButton;
	public PanelToggleButton BoxButton;
	public PanelToggleButton CardButton;
	public PanelToggleButton SkillButton;
	public PanelToggleButton TurnButton;

	/// <summary>
	/// The array of all panel buttons (all buttons exclude End)
	/// </summary>
	public PanelToggleButton[] PanelButtons
	{
		get
		{
			if (_panelButtons == null)
				_panelButtons = new PanelToggleButton[]
				{
						BoxButton, CardButton, SkillButton, TurnButton
				};

			return _panelButtons;
		}
	}

	public override Button[] Buttons
	{
		get { return PanelButtons.Select(p => p.Button).Union(new[] { EndButton }).ToArray(); }
	}

	private PanelToggleButton[] _panelButtons;

	public void Init()
	{
		Assert.IsNotNull(EndButton);
		foreach (var button in PanelButtons)
		{
			button.Init();
			button.Button.onClick.AddListener(() => HideAllExcept(button));
		}

		EndButton.onClick.AddListener(() => EventEndTurn.TryEndTurn());
	}

	public void HideAllExcept(PanelToggleButton panelButton)
	{
		foreach (var pb in PanelButtons.Where(x => x != panelButton))
		{
			pb.Panel.gameObject.SetActive(false);
		}
	}

	private CardActionGroup GetCardGroup(CardObject card)
	{
		var entity = card.Entity;
		var ui = GameUI.Instance;
		if (entity.isDeckCard || entity.hasCardResource)
		{
			if (entity.hasInBox)
				return ui.BoxGroup;
			else
				return ui.DeckGroup;
		}
		else if (entity.isSkillCard)
		{
			return ui.SkillGroup;
		}
		return null;
	}

	public override void OnCardClick(CardObject card)
	{
		var group = GetCardGroup(card);
		if (group != null)
		{
			ShowSubAction(group);
			group.OnCardClick(card);
		}
	}
}