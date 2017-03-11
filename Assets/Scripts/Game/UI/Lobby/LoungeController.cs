using UnityEngine;
using UnityEngine.UI;

namespace End.Lobby.UI
{
	public class LoungeController : MonoBehaviour
	{
		public LoungeConnectionDialogue ConnectionDialogue;

		public Button HostButton;
		public Button JoinButton;

		/// <summary>
		/// click on Host
		/// </summary>
		public void HostButtonClick()
		{
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
