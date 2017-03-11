using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace End
{
	public class LoungeNetworkManager : NetworkLobbyManager
	{
		public LoungeConnectionDialogue ConnectionDialouge;

		public Button HostButton;
		public Button JoinButton;

		/// <summary>
		/// click on Host
		/// </summary>
		public void HostButtonClick()
		{
			Debug.Log("Start Host");
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
			Debug.Log("join server : " + ConnectionDialouge.GetIpAddress());
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
