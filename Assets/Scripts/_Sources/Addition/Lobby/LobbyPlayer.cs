using Network;
using UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Lobby
{
	public class LobbyPlayer : MonoBehaviour
	{
		readonly Color Color_Yellow = new Color(1, 237f / 255, 0);
		readonly Color Color_Orange = new Color(1, 143 / 255f, 0);
		readonly Color Color_Green = new Color(36f / 255, 1, 46f / 255);

		public Text PlayerNameText;
		public Text PlayerStatusText;
		public Icon PlayerIcon;

		private Player _player;
		private LobbyController _controller;

		private void Awake()
		{
			Assert.IsNotNull(PlayerNameText);
			Assert.IsNotNull(PlayerStatusText);
			Assert.IsNotNull(PlayerIcon);
		}

		public void Init(LobbyController controller)
		{
			_controller = controller;
		}

		public void SetPlayer(Player player)
		{
			_player = player;

			_player.OnNameChangedCallback += SetName;
			_player.OnReadyStateChangedCallback += SetStatus;
			_player.OnIconChangedCallback += SetIcon;
		}

		private void OnDestroy()
		{
			if (_player == null) return;

			_player.OnNameChangedCallback -= SetName;
			_player.OnReadyStateChangedCallback -= SetStatus;
			_player.OnIconChangedCallback -= SetIcon;
		}

		private void Update()
		{
			if(_player != null && !_player.IsReady)
			{
				PlayerStatusText.color = Color.Lerp(Color_Yellow, Color_Orange, Mathf.PingPong(Time.time, 2f));
			}
		}

		public void SetName(string name)
		{
			PlayerNameText.text = name;
		}

		public void SetStatus(bool isReady)
		{
			PlayerStatusText.text = isReady ? "Ready" : "Waiting";
			
			if(isReady)
			{
				PlayerStatusText.color = Color_Green;
			}
		}

		public void SetIcon(int iconId)
		{
			PlayerIcon.SetImage(_controller.GetPlayerIcon((Title.PlayerIcon)iconId));
		}

		public void SetIcon(Sprite icon)
		{
			PlayerIcon.SetImage(icon);
		}
	}
}
