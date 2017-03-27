using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class CardContainer : MonoBehaviour
	{
		public PlayerDeck PlayerDeckPrefabs;
		public Dictionary<int, PlayerDeck> PlayerDecks;

		public PlayerDeck CreateContainer(int playerId)
		{
			var deck = Instantiate(PlayerDeckPrefabs);
			deck.Init();
			deck.name = "Player " + playerId;
			deck.transform.SetParent(transform, false);

			PlayerDecks.Add(playerId, deck);
			deck.gameObject.SetActive(false);

			return deck;
		}

		public void Awake()
		{
			PlayerDecks = new Dictionary<int, PlayerDeck>();
			var middleDeck = CreateContainer(0);
			middleDeck.name = "Middle Deck";
		}
	}
}
