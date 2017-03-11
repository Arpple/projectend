using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace End
{
	public class LoungeController : MonoBehaviour
	{
		public LobbyNetworkInfo NetworkInfo;
		public LoungeConnectionDialogue ConnectionDialogue;

		public Button HostButton;
		public Button JoinButton;

		/// <summary>
		/// click on Host
		/// </summary>
		public void HostButtonClick()
		{
			NetworkInfo.IsHost = true;
			Debug.Log("host server");
		}

		/// <summary>
		/// click on Join
		/// </summary>
		public void JoinButtonClick()
		{
			ShowConnectionDialogue();
		}

		/// <summary>
		/// in dialogue click cancel
		/// </summary>
		public void ConnectionDialogueCancel()
		{
			CloseConnectionDialogue();
		}

		/// <summary>
		/// in dialogue click ok
		/// </summary>
		public void ConnectionDialogueConfirm()
		{
			var ipAddress = ConnectionDialogue.GetIpAddress();
			if(ipAddress != "")
			{
				CloseConnectionDialogue();
				NetworkInfo.IsHost = false;
				NetworkInfo.JoinIpAddress = ConnectionDialogue.GetIpAddress();
				Debug.Log("join server : " + ConnectionDialogue.GetIpAddress());
			}
		}

		private void ShowConnectionDialogue()
		{
			ConnectionDialogue.Show();
			HostButton.interactable = false;
			JoinButton.interactable = false;
		}

		private void CloseConnectionDialogue()
		{
			ConnectionDialogue.Close();
			HostButton.interactable = true;
			JoinButton.interactable = true;
		}


	}

}
