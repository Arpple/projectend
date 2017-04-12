using Entitas;
using UnityEngine;

[Tile, Unit, Card]
public class SpriteComponent : IComponent
{
	public Sprite Sprite;
}