using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;
using End.Network;

namespace End.Lobby
{
	public class LobbyController : MonoBehaviour
	{
		public static LobbyController Instance;

		public GameObject PlayerContainer;
		public Button BackButton;
		public Button ReadyButton;
		public Button WaitButton;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(PlayerContainer);
			Assert.IsNotNull(BackButton);
			Assert.IsNotNull(ReadyButton);
			Assert.IsNotNull(WaitButton);
		}

		public void AddPlayer(Player player)
		{
			player.transform.SetParent(PlayerContainer.transform, false);
		}

		public void Back()
		{
		}

		//#region Client
		//public override void OnStopClient()
		//{
		//	base.OnStopClient();
		//	SceneManager.LoadScene(Scene.Lounge.ToString());
		//	Destroy(gameObject);
		//}

		//public override void OnStopServer()
		//{
		//	base.OnStopServer();
		//	SceneManager.LoadScene(Scene.Lounge.ToString());
		//	Destroy(gameObject);
		//}
		//#endregion

	}
}
