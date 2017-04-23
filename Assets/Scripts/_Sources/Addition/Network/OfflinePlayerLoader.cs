using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Network
{
	public class OfflinePlayerLoader : MonoBehaviour, IPlayerLoader
	{
		public Transform PlayersParent;

		public List<Player> GetAllPlayer()
		{
			return PlayersParent.GetComponentsInChildren<Player>(true).ToList();
		}

		public Player GetLocalPlayer()
		{
			return PlayersParent.GetChild(0).GetComponent<Player>();
		}
	}
}