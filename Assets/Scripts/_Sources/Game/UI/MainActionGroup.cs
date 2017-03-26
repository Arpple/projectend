using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class MainActionGroup
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

		public ActionButton EndButton;
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

		private PanelToggleButton[] _panelButtons;

		public void Init()
		{
			Assert.IsNotNull(EndButton);
			foreach(var button in PanelButtons)
			{
				button.Init();
				button.Button.onClick.AddListener(() => HideAllExcept(button));
			}
			
		}

		public void HideAllExcept(PanelToggleButton panelButton)
		{
			foreach(var pb in PanelButtons.Where(x => x != panelButton))
			{
				pb.Panel.gameObject.SetActive(false);
			}
		}
	}
}
