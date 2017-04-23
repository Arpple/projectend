using System.Collections;

namespace Network
{
	public class NetworkSceneLoader : SceneLoader
	{
		protected override void SetupLocalPlayer(Player player)
		{
			_localPlayer.AllPlayerSceneLoadedAction = SetReady;
		}

		IEnumerator SendMessageSceneComplete()
		{
			while(!_localPlayer.IsClientSceneLoaded)
			{
				NetworkController.Instance.ClientSceneChangedCallback = _localPlayer.CmdSendMessageSceneLoaded;
				yield return null;
			}
		}

		protected override void OnSetupComplete()
		{
			StartCoroutine(SendMessageSceneComplete());
		}
	} 
}