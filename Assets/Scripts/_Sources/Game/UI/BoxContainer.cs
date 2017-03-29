using UnityEngine;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class BoxContainer : MonoBehaviour
	{
		public PlayerBox PlayerBoxPrefabs;
		public Dictionary<int, PlayerBox> PlayerBoxs;

		public PlayerBox CreateContainer(int playerId)
		{
			var box = Instantiate(PlayerBoxPrefabs);
			box.Init();
			box.name = "Player " + playerId;
			box.transform.SetParent(transform, false);

			PlayerBoxs.Add(playerId, box);
			box.gameObject.SetActive(false);

			return box;
		}

		public void Init()
		{
			PlayerBoxs = new Dictionary<int, PlayerBox>();
		}
	}
}