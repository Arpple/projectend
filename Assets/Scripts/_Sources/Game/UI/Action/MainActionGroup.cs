using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Game.UI
{
	[Serializable]
	public class MainActionGroup : ActionGroup
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
			get { return PanelButtons.Select(p => p.Button).ToArray(); }
		}

		private PanelToggleButton[] _panelButtons;

		public void Init()
		{
			Assert.IsNotNull(EndButton);
			foreach(var button in PanelButtons)
			{
				button.Init();
				button.Button.onClick.AddListener(() => HideAllExcept(button));
			}

			EndButton.onClick.AddListener(() => EventEndTurn.TryEndTurn());
		}

		public void HideAllExcept(PanelToggleButton panelButton)
		{
			foreach(var pb in PanelButtons.Where(x => x != panelButton))
			{
				pb.Panel.gameObject.SetActive(false);
			}
		}

		public void ToggleButtons(bool isVisible)
		{
			foreach(var pb in PanelButtons)
			{
				pb.Button.gameObject.SetActive(isVisible);
			}
			EndButton.gameObject.SetActive(isVisible);
		}

		protected override void Show()
		{
			ToggleButtons(true);
		}

		protected override void Hide()
		{
			ToggleButtons(false);
		}
	}
}
