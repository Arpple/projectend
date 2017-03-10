using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace End
{
	public class Player : NetworkBehaviour
	{
		public const int MAX_PLAYER = 8;

		public static int PlayerCount;

		[SyncVar] public int PlayerId;
		[SyncVar] public Character SelectedCharacter;

		void Start()
		{
			PlayerLoader.Instance.LoadPlayer(this);
		}
	}

}
