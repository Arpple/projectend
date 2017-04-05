using UnityEngine;
using Entitas;

namespace Game
{
	[Game, Tile]
	public class ViewComponent : IComponent
	{
		public GameObject GameObject;
	}

}
