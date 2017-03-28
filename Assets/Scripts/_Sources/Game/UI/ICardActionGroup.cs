using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	public interface ICardActionGroup
	{
		void SetAction(CardObject card);
	}
}
