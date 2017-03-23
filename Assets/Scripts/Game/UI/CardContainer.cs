using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class CardContainer : MonoBehaviour
	{
		public Dictionary<int, GameObject> PlayerDecks;

		public GameObject CreateContainer(int playerId)
		{
			var go = new GameObject()
			{
				name = playerId == 0 ? "Middle Deck" : "Player " + playerId
			};
			go.transform.SetParent(transform, false);

			PlayerDecks.Add(playerId, go);

			return go;
		}

		private void Awake()
		{
			PlayerDecks = new Dictionary<int, GameObject>();
		}
	}
}
