using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
	public class MainMissionSelectorObject : MonoBehaviour
	{
		public Text MissionNameText;

		private MainMissionData _data;

		public void SetMissionData(MainMissionData data)
		{
			_data = data;
			MissionNameText.text = data.Name;
		}

		public MainMission GetMissionType()
		{
			return _data.Type;
		}
	}
}
