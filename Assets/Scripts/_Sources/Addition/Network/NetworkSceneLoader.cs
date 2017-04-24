using System.Collections;
using UnityEngine;

namespace Network
{
	public class NetworkSceneLoader : SceneLoader
	{
		protected override void SetupLocalPlayer(Player player)
		{
			_localPlayer.AllPlayerSceneLoadedAction = SetReady;
		}

		IEnumerator SendSceneLoaded()
		{
			while(!IsReady())
			{
				_localPlayer.CmdSendMessageSceneLoaded();
				yield return new WaitForSeconds(1); 
			}
		}

		protected override void OnSetupComplete()
		{
			StartCoroutine(SendSceneLoaded());
		}
	} 
}