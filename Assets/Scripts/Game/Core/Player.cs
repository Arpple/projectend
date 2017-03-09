using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace End
{
	public class Player : NetworkBehaviour
	{
		public static int PlayerCount;

		[SyncVar] public int PlayerId;

		void Start()
		{
			PlayerLoader.Instance.LoadPlayer(this);
		}
	}

}
