//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Assertions;

//namespace Game
//{
//	public class PlayerLoader : MonoBehaviour
//	{
//		public static PlayerLoader Instance;

//		private int _targetPlayerCount;

//		public List<Player> PlayerList
//		{
//			get; private set;
//		}

//		public bool IsComplete
//		{
//			get { return PlayerList.Count == _targetPlayerCount && _targetPlayerCount > 0; }
//		}

//		private void Awake()
//		{
//			Instance = this;
//			PlayerList = new List<Player>();
//		}

//		private void Start()
//		{
//			if(GameController.IsOffline)
//			{
//				int id = 1;
//				foreach(var player in transform.GetComponentsInChildren<Player>(true))
//				{
//					player.gameObject.SetActive(true);
//					player.PlayerId = id;
//					id++;
//				}
//			}
//		}

//		public void SetTargetPlayerCount(int count)
//		{
//			_targetPlayerCount = count;
//		}

//		public void LoadPlayer(Player player)
//		{
//			Assert.IsFalse(PlayerList.Contains(player));
//			PlayerList.Add(player);
//			player.transform.SetParent(transform);
//		}
//	}
//}

