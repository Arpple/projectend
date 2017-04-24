using UnityEngine;
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
	}
}