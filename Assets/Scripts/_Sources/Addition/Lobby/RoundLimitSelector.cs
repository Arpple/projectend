using Network;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lobby
{
	public class RoundLimitSelector : MonoBehaviour
	{
		public Button LeftButton;
		public Button RightButton;
		public UnityAction<int> OnRoundLimitChanged;

		private int _roundLimit;

		private void Awake()
		{
			_roundLimit = 20;
		}

		private void Start()
		{
			if (!NetworkController.IsServer)
			{
				Hide();
			}
			LeftButton.onClick.AddListener(DecreaseRound);
			RightButton.onClick.AddListener(IncreaseRound);
		}

		public void UpdateButtonInteractable()
		{
			LeftButton.interactable = _roundLimit > 1;
			RightButton.interactable = _roundLimit < 100;
		}

		public void SetRound(int round)
		{
			_roundLimit = round;
			UpdateRound();
		}

		public void DecreaseRound()
		{
			_roundLimit -= 1;
			UpdateRound();
		}

		public void IncreaseRound()
		{
			_roundLimit += 1;
			UpdateRound();
		}

		public void Hide()
		{
			LeftButton.gameObject.SetActive(false);
			RightButton.gameObject.SetActive(false);
		}

		public void Show()
		{
			LeftButton.gameObject.SetActive(true);
			LeftButton.gameObject.SetActive(true);
		}

		private void UpdateRound()
		{
			UpdateButtonInteractable();
			if (OnRoundLimitChanged != null)
			{
				OnRoundLimitChanged(_roundLimit);
			}
		}
	}
}
