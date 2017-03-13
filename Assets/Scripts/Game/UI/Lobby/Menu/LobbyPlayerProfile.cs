using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Lobby.UI
{
	public class LobbyPlayerProfile : MonoBehaviour
	{
		public Image PlayerIconImage;
		public Text PlayerName;

		private void Awake()
		{
			Assert.IsNotNull(PlayerIconImage);
			Assert.IsNotNull(PlayerName);
		}
	}

}
