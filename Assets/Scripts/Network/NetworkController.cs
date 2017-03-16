using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End
{
	public class NetworkController : NetworkManager
	{
		public static NetworkController Instance;

		public delegate void ClientErrorCallback(int errorCode);
		public event ClientErrorCallback OnClientErrorCallback;

		[Header("Local Player")]
		public string LocalPlayerName;
		public string LocalPlayerIconPath;

		private void Awake()
		{
			if(Instance != null)
			{
				DestroyImmediate(gameObject);
				return;
			}
			Instance = this;
		}

		public void Stop()
		{
			Shutdown();
		}

		public override void OnClientError(NetworkConnection conn, int errorCode)
		{
			base.OnClientError(conn, errorCode);
			if (OnClientErrorCallback != null) OnClientErrorCallback(errorCode);
		}
	}
}
