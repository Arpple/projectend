using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.UI
{
	public class TurnPanel : MonoBehaviour
	{
		public TurnNode TurnNodePrefabs;
		public List<TurnNode> TurnNodes;
		public Transform TurnNodeParent;

		private void Awake()
		{
			Assert.IsNotNull(TurnNodePrefabs);
			TurnNodes = new List<TurnNode>();
			TurnNodeParent = TurnNodeParent ?? transform;
		}

		public TurnNode CreateTurnNode()
		{
			var node = Instantiate(TurnNodePrefabs);
			TurnNodes.Add(node);
			node.transform.SetParent(TurnNodeParent, false);
			return node;
		}
	}

}
