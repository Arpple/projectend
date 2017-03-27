using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	public delegate void GroupCloseHandler();

	public interface ICardActionGroup
	{
		Button[] Buttons { get; }

		void ShowAction(CardObject card);
		void CloseAction();

		event GroupCloseHandler OnGroupClosed;
	}
}
