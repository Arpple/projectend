using UnityEngine;
using UnityEngine.Networking;

namespace End
{
	public class LobbyNetworkInfo : MonoBehaviour
	{
		public static LobbyNetworkInfo Instace;

		public bool IsHost;
		public string JoinIpAddress;

		private void Start()
		{
			Instace = this;
			DontDestroyOnLoad(this);
		}
	}

}
