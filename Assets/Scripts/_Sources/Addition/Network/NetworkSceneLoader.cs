using UnityEngine;

namespace Network
{
	public class NetworkSceneLoader : SceneLoader
	{
		protected override void SetupLocalPlayer(Player player)
		{
			_localPlayer.AllPlayerSceneLoadedAction = SetReady;
		}

		protected override void OnSetupComplete()
		{
			NetworkController.Instance.ClientSceneChangedCallback = _localPlayer.CmdSendMessageSceneLoaded;
		}
	} 
}