using UnityEngine;
using Entitas;

namespace Game
{
	[Game, Card, Unit]
	public class OwnerComponent : IComponent
	{
		public GameEntity Entity;
	}

}
