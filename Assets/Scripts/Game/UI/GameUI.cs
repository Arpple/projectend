using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		public ActionButtonGroup ActionButtonGroup;

		private void Awake()
		{
			Instance = this;

			ActionButtonGroup.Awake();
		}
	}
}

