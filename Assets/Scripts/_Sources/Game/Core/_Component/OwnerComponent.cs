using UnityEngine;
using Entitas;

namespace Game
{
	[Game, Card]
	public class OwnerComponent : IComponent
	{
		public GameEntity Entity;
	}

}
