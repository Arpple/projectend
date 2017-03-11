using UnityEngine.UI;
using UnityEngine;

namespace End
{
	public class LoungeConnectionDialogue : MonoBehaviour
	{
		public Text IpInputField;

		public string GetIpAddress()
		{
			return IpInputField.text;
		}

		public void BackButtonClick()
		{

		}

		public void JoinButtonClick()
		{

		}

		/// <summary>
		/// when this dialogue is show
		/// </summary>
		public void Show()
		{
			gameObject.SetActive(true);
		}

		/// <summary>
		/// when this dialogue is close
		/// </summary>
		public void Close()
		{
			gameObject.SetActive(false);
		}
	}
}
