using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
	public class MainMissionDisplay : MonoBehaviour
	{
		public Text MissionNameText;

		public void ShowMission(MainMissionData data)
		{
			MissionNameText.text = data.Name;
		}
	}
}
