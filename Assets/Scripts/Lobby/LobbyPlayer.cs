using End.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End.Lobby
{
	public class LobbyPlayer : NetworkLobbyPlayer
	{
		readonly Color Color_Yellow = new Color(1, 237f / 255, 0);
		readonly Color Color_Orange = new Color(1, 143 / 255f, 0);
		readonly Color Color_Green = new Color(36f / 255, 1, 46f / 255);

		public Text PlayerNameText;
		public Text PlayerStatusText;
		public Icon PlayerIcon;

		private bool _isReady;

		private void Awake()
		{
			Assert.IsNotNull(PlayerNameText);
			Assert.IsNotNull(PlayerStatusText);
			Assert.IsNotNull(PlayerIcon);
		}

		private void Update()
		{
			if(!_isReady)
			{
				PlayerStatusText.color = Color.Lerp(Color_Yellow, Color_Orange, Mathf.PingPong(Time.time, 2f));
			}
		}

		public void SetName(string name)
		{
			PlayerNameText.text = name;
		}

		public void SetReady(bool isReady)
		{
			_isReady = isReady;
			PlayerStatusText.text = isReady ? "Ready" : "Waiting";
			
			if(isReady)
			{
				PlayerStatusText.color = Color_Green;
			}
		}
	}
}
