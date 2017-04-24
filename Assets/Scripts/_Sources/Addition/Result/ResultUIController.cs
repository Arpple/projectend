using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Result
{
	public class ResultUIController : MonoBehaviour
	{
		public PlayerResultObject ResultObjectPrefabs;
		public Transform ResultObjectParent;

		[Header("LocalResult")]
		public Text ResultText;
		public Color VictoryTextColor;
		public Color DefeatTextColor;

		[Header("Action")]
		public Button BackButton;

		private void Start()
		{
			BackButton.onClick.AddListener(BackToTitle);
		}

		public PlayerResultObject CreatePlayerResult(GameEntity player)
		{
			return Instantiate(ResultObjectPrefabs, ResultObjectParent, false);
		}

		public void SetResultTextVictory()
		{
			ResultText.text = "Victory!";
			ResultText.color = VictoryTextColor;
		}

		public void SetResultTextDefeat()
		{
			ResultText.text = "Defeated";
			ResultText.color = DefeatTextColor;
		}

		private void BackToTitle()
		{
			SceneManager.LoadScene(GameScene.Title.ToString());
		}
	}
}