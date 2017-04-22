using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Result
{
	public class PlayerResultObject : MonoBehaviour
	{
		public Icon PlayerIcon;
		public Text PlayerNameText;
		public Text CharacterNameText;
		public Text PlayerMissionNameText;
		public Image MissionCompleteImage;

		private void Start()
		{
			Assert.IsNotNull(PlayerIcon);
			Assert.IsNotNull(PlayerNameText);
			Assert.IsNotNull(CharacterNameText);
			Assert.IsNotNull(PlayerMissionNameText);
			Assert.IsNotNull(MissionCompleteImage);
		}

		public void SetPlayerIcon(Sprite image)
		{
			PlayerIcon.SetImage(image);
		}

		public void SetPlayerName(string name)
		{
			PlayerNameText.text = name;
		}

		public void SetCharacterName(string name)
		{
			CharacterNameText.text = name;
		}

		public void SetPlayerMissionName(string name)
		{
			PlayerMissionNameText.text = name;
		}

		public void DisplayMissionComplete()
		{
			MissionCompleteImage.gameObject.SetActive(true);
		}

		public void DisplayMissionFail()
		{
			MissionCompleteImage.gameObject.SetActive(false);
		}
	} 
}