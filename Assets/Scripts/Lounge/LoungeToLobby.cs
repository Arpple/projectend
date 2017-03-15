using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Lounge
{
	public class LoungeToLobby : MonoBehaviour
	{
		public static LoungeToLobby Instance;

		[Header("PlayerProfile")]
		public string PlayerName;
		public string PlayerIconPath;

		[Header("Connection")]
		public bool IsHost;
		public string ConnectingIpAddress;
		

		private void Awake()
		{
			DontDestroyOnLoad(this);
			Instance = this;
		}
	}
}

