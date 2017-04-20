using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class TurnPanel : MonoBehaviour
{
	public TurnNode TurnNodePrefabs;
	public List<TurnNode> TurnNodes;
	public Transform TurnNodeParent;
	public Text RoundText;

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

	public void UpdateRoundText(int round, int limit)
	{
		var str = "Round " + round;
		if(limit > 0)
		{
			str += "/" + limit;
		}

		RoundText.text = str;
	}
}