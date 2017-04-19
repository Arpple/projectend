using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
	public class RoundLimitDisplay : MonoBehaviour
	{
		public Text RoundLimitText;

		public void ShowRoundLimit(int round)
		{
			RoundLimitText.text = round.ToString();
		}
	}
}
