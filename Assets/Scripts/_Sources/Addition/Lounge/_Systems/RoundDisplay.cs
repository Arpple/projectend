using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class RoundDisplay : MonoBehaviour
	{
		public Text DisplayText;

		const string TEXT_HEADER = "Round Limit";

		public void SetRoundLimit(int count)
		{
			DisplayText.text = TEXT_HEADER + Environment.NewLine + string.Format("-{0}-", count);
		}

	}
}