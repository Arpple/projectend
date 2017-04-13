using Entitas;
using UnityEngine;

[Tile]
public class ResourceComponent : IComponent
{
	public Resource Type;
	public Sprite EmptySprite;
}
