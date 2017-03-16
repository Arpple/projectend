using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End
{
	public class NetworkController : NetworkManager
	{
		public static NetworkController Instance;

		[Header("Local Player")]
		public string LocalPlayerName;
		public string LocalPlayerIconPath;

		private void Awake()
		{
			Instance = this;
		}
	}
}
