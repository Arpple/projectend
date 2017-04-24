using System;
using System.Collections.Generic;
using UnityEngine;

namespace Network
{
	public class NetworkPlayerLoader : MonoBehaviour, IPlayerLoader
	{
		public List<Player> GetAllPlayer()
		{
			return NetworkController.Instance.AllPlayers;
		}

		public Player GetLocalPlayer()
		{
			return NetworkController.Instance.LocalPlayer;
		}

		public bool IsNetwork()
		{
			return true;
		}
	} 
}