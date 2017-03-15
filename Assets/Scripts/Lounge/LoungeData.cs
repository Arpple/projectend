using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Lounge
{
	public class LoungeData : MonoBehaviour
	{
		public static LoungeData Instance;

		[Header("PlayerProfile")]
		public string PlayerName;
		public string PlayerIconPath;

		[Header("Connection")]
		public bool IsHost;
		public string ConnectingIpAddress;
		

		private void Awake()
		{
			//use old data
			if(Instance != null)
			{
				Destroy(gameObject);
				return;
			}

			DontDestroyOnLoad(this);
			Instance = this;
		}
	}
}

