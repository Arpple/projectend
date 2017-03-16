//using End.UI;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Assertions;
//using UnityEngine.Networking;

//namespace End.Lobby
//{
//	public class LobbyPlayer : NetworkLobbyPlayer
//	{
//		//constant
//		readonly Color Color_Yellow = new Color(1, 237f / 255, 0);
//		readonly Color Color_Orange = new Color(1, 143 / 255f, 0);
//		readonly Color Color_Green = new Color(36f / 255, 1, 46f / 255);

//		//ui
//		public Text PlayerNameText;
//		public Text PlayerStatusText;
//		public Icon PlayerIcon;

//		//sync properties
//		[SyncVar(hook = "OnNameChanged")]
//		public string PlayerName;

//		[SyncVar(hook = "OnStatusChanged")]
//		public bool IsReady;

//		[SyncVar(hook = "OnIconChanged")]
//		public string playerIconPath;
		

//		private bool _isReady;

//		public LobbyController Lobby
//		{
//			get { return LobbyController.Instance; }
//		}

//		private void Awake()
//		{
//			Assert.IsNotNull(PlayerNameText);
//			Assert.IsNotNull(PlayerStatusText);
//			Assert.IsNotNull(PlayerIcon);
//		}

//		private void Start()
//		{
//			Assert.IsNotNull(Lobby);
//		}

//		private void Update()
//		{
//			if(!_isReady)
//			{
//				PlayerStatusText.color = Color.Lerp(Color_Yellow, Color_Orange, Mathf.PingPong(Time.time, 2f));
//			}
//		}

//		public void OnNameChanged(string name)
//		{
//			PlayerNameText.text = name;
//		}

//		public void OnStatusChanged(bool isReady)
//		{
//			_isReady = isReady;
//			PlayerStatusText.text = isReady ? "Ready" : "Waiting";
			
//			if(isReady)
//			{
//				PlayerStatusText.color = Color_Green;
//			}
//		}

//		public void OnIconChanged(string iconPath)
//		{
//			playerIconPath = iconPath;
//			PlayerIcon.SetImage(Resources.Load<Sprite>(iconPath));
//		}

//		#region Network
//		public override void OnStartLocalPlayer()
//		{
//			base.OnStartLocalPlayer();

//			CmdSetName(LoungeData.PlayerName);
//			CmdSetIcon(LoungeData.PlayerIconPath);
//			CmdSetStatus(false);

//			var readyBtn = Lobby.ReadyButton;
//			var waitBtn = Lobby.WaitButton;

//			readyBtn.onClick.RemoveAllListeners();
//			readyBtn.onClick.AddListener(() =>
//			{
//				CmdSetStatus(true);
//				SendReadyToBeginMessage();
//				readyBtn.gameObject.SetActive(false);
//				waitBtn.gameObject.SetActive(true);
//			});

			
//			waitBtn.onClick.RemoveAllListeners();
//			waitBtn.onClick.AddListener(() =>
//			{
//				CmdSetStatus(false);
//				SendNotReadyToBeginMessage();
//				readyBtn.gameObject.SetActive(true);
//				waitBtn.gameObject.SetActive(false);
//			});
//		}

//		public override void OnClientEnterLobby()
//		{
//			base.OnClientEnterLobby();

//			Lobby.AddPlayer(this);
//		}
//		#endregion

//		#region Command
//		[Command]
//		public void CmdSetName(string name)
//		{
//			PlayerName = name;
//		}

//		[Command]
//		public void CmdSetStatus(bool isReady)
//		{
//			IsReady = isReady;
//		}

//		[Command]
//		public void CmdSetIcon(string path)
//		{
//			playerIconPath = path;
//		}
//		#endregion
//	}
//}
