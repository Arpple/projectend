using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;

namespace Result
{
	public class ResultUIController : MonoBehaviour
	{
		public PlayerResultObject ResultObjectPrefabs;
		public Transform ResultObjectParent;

		public PlayerResultObject CreatePlayerResult(GameEntity player)
		{
			return Instantiate(ResultObjectPrefabs, ResultObjectParent, false);
		}
	}
}