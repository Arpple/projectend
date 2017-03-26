using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class CardContainer : MonoBehaviour
	{
		public GameObject PlayerDeckPrefabs;
		public Dictionary<int, GameObject> PlayerDecks;

		public GameObject CreateContainer(int playerId)
		{
			var go = Instantiate(PlayerDeckPrefabs);
			go.name = "Player " + playerId;
			go.transform.SetParent(transform, false);

			PlayerDecks.Add(playerId, go);
			go.SetActive(false);

			return go;
		}

		public void Awake()
		{
			PlayerDecks = new Dictionary<int, GameObject>();
			var middleDeck = CreateContainer(0);
			middleDeck.name = "Middle Deck";
		}
	}
}
