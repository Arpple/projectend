using UnityEngine;
using Entitas;

namespace Game
{
	[Game]
	public class OwnerComponent : IComponent
	{
		public GameEntity Entity;
	}

}
