using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public MainActionGroup MainGroup;

		private void Start()
		{
			MainGroup.Init();
		}
	}
}
