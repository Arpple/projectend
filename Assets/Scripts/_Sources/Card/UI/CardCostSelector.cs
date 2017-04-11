using System.Collections.Generic;
using UI;
using UnityEngine.UI;

public class CardCostSelector : ActionGroup
{
	public Button ConfirmButton;
	public Button CancelButton;

	private List<CardObject> _selectedCard;

	private Button[] _buttons;
	public override Button[] Buttons
	{
		get
		{
			if (_buttons == null)
				_buttons = new Button[] { ConfirmButton, CancelButton };
			return _buttons;
		}
	}
}