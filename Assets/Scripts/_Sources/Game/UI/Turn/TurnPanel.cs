using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class TurnPanel : MonoBehaviour
	{
		public TurnNode TurnNodePrefabs;
		public List<TurnNode> TurnNodes;

		private void Awake()
		{
			Assert.IsNotNull(TurnNodePrefabs);
			TurnNodes = new List<TurnNode>();
		}

		public TurnNode CreateTurnNode()
		{
			var node = Instantiate(TurnNodePrefabs);
			TurnNodes.Add(node);
			return node;
		}
	}

}
