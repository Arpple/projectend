using UnityEngine;
using Entitas;

namespace Game
{
	[Game, Tile, Card, Unit]
	public class ViewComponent : IComponent
	{
		public GameObject GameObject;
	}

}
