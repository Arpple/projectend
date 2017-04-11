using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UI;

namespace Title
{
	public class ConnectionDialogue : MonoBehaviour{
		public InputField IpInputField;
		public Button BackButton;
		public Button JoinButton;

		public delegate void BackButtonAction();
		public delegate void JoinButtonAction();

		public event BackButtonAction OnBackButton;
		public event JoinButtonAction OnJoinButton;

		public string IpAddress
		{
			get { return IpInputField.text; }
		}

		private void Awake()
		{
			Assert.IsNotNull(IpInputField);
			Assert.IsNotNull(BackButton);
			Assert.IsNotNull(JoinButton);
		}

		private void Start()
		{
			IpInputField.text = "127.0.0.1";
			IpInputField.onEndEdit.AddListener((s) => JoinButton.interactable = s != "");
		}

		public void Back()
		{
			gameObject.SetActive(false);
			if (OnBackButton != null) OnBackButton();
		}

		public void Join()
		{
			gameObject.SetActive(false);
			if (OnJoinButton != null) OnJoinButton();
		}
	}
}
