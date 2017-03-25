using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		public ActionButtonController ActionButton;
		public InventoryGroup InventoryGroup;
		public GameObject TurnPanel;

		private Dictionary<ActionButton, GameObject> _controllingPanels;
		private ActionButton _lastAction;

		public GameObject[] MainPanels
		{
			get; private set;
		}

		private void Awake()
		{
			Instance = this;

			ActionButton.Awake();
			InventoryGroup.Awake();

			Assert.IsNotNull(TurnPanel);

			_controllingPanels = new Dictionary<UI.ActionButton, GameObject>();
		}

		private void Start()
		{
			MainPanels = new GameObject[] {InventoryGroup.BoxContainer,
				InventoryGroup.CardContainer.gameObject,
				InventoryGroup.SkillContainer,
				TurnPanel
			};

			//setup action button
			//-- main
			var main = ActionButton.MainAction;
			_controllingPanels[main.BoxButton] = InventoryGroup.BoxContainer;
			_controllingPanels[main.CardButton] = InventoryGroup.CardContainer.gameObject;
			_controllingPanels[main.SkillButton] = InventoryGroup.SkillContainer;
			_controllingPanels[main.TurnButton] = TurnPanel;

			foreach(var act in main.AllActions.Where(x => x != main.EndButton))
			{
				act.OnClickCallback += OnMainActionClicked;
			}

			main.EndButton.OnClickCallback += (act) =>
			{
				EventEndTurn.TryEndTurn();
			};

		}

		public void OnMainActionClicked(ActionButton act)
		{
			if(_lastAction == act)
			{
				_controllingPanels[act].SetActive(false);
				_lastAction = null;
				return;
			}

			//hide other main panel
			foreach(var obj in MainPanels)
			{
				obj.SetActive(false);
			}

			//show controlling panel
			_controllingPanels[act].SetActive(true);

			_lastAction = act;
		}

		
	}
}

