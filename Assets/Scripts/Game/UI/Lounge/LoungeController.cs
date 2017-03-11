using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace End
{
	public class LoungeController : MonoBehaviour
	{
		public LobbyNetworkInfo NetworkInfo;
		public LoungeConnectionDialogue ConnectionDialouge;

		public Button HostButton;
		public Button JoinButton;

		/// <summary>
		/// click on Host
		/// </summary>
		public void HostButtonClick()
		{
			NetworkInfo.IsHost = true;
			Debug.Log("host server");
			SceneManager.LoadScene("Lobby");
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
			CloseConnectionDialogue();
			NetworkInfo.IsHost = false;
			NetworkInfo.JoinIpAddress = ConnectionDialouge.GetIpAddress();
			Debug.Log("join server : " + ConnectionDialouge.GetIpAddress());
			SceneManager.LoadScene("Lobby");
		}

		private void ShowConnectionDialogue()
		{
			ConnectionDialouge.Show();
			HostButton.enabled = false;
			JoinButton.enabled = false;
		}

		private void CloseConnectionDialogue()
		{
			ConnectionDialouge.Close();
			HostButton.enabled = true;
			JoinButton.enabled = true;
		}


	}

}
