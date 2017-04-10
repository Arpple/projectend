using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using System.Linq;

namespace Game
{
	[Game, Unique]
	public class PlayingOrderComponent : IComponent
	{
		public List<GameEntity> PlayerOrder;

		public void ReOrder()
		{
			var first = PlayerOrder.First();
			PlayerOrder.RemoveAt(0);
			PlayerOrder.Add(first);
		}
	}
}
