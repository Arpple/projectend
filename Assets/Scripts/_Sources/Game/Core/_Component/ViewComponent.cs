using UnityEngine;
using Entitas;

namespace Game
{
	[Game, Tile, Card]
	public class ViewComponent : IComponent
	{
		public GameObject GameObject;
	}

}
