using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class MissionBookMainPage : MonoBehaviour
	{
		public Button WorldPageButton;
		public Button PlayerPageButton;

		[Header("Main")]
		public Text WorldMissionNameText;
		public Text WorldMissionDescriptionText;

		[Header("Player")]
		public Text PlayerMissionNameText;
		public Text PlayerMissionTargetText;
		public Text PlayerMissionDescriptionText;

		public void SetWorldMission(MissionData mission)
		{
			WorldMissionNameText.text = mission.Name; ;
			WorldMissionDescriptionText.text = mission.Description;
		}

		public void SetPlayerMission(MissionData mission)
		{
			PlayerMissionNameText.text = mission.Name;
			PlayerMissionDescriptionText.text = mission.Description;
		}

		public void SetPlayerMissionTarget(GameEntity target)
		{
			PlayerMissionTargetText.text = target.player.ToString();
		}

		public void ShowPage()
		{
			gameObject.SetActive(true);
		}

		public void HidePage()
		{
			gameObject.SetActive(false);
		}
	}
}
