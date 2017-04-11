using UnityEngine;
using Entitas;

namespace Game
{
	[Tile]
	public class SpriteComponent : IComponent
	{
		public Sprite Sprite;
	}
}
